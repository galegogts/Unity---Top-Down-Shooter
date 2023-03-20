using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public int inimigoTipo = 0;
    public float velocidade = 0;
    private GameObject player;
    public GameObject ExplosionPrefab;

    private bool prepararTiro = false;

    private float ShootTime = 5;
    private float ShootNext = 0f;
    bool multiSingleShoot = false;
    Gun gun;

    Score score;
    private void Start() {
        gun = GetComponent<Gun>();
        player = GameObject.FindGameObjectWithTag("Player");
        score = FindObjectOfType<Score>();
    }

    void Update(){
        if (this.GetComponent<Life>().vida > 0 && player.GetComponent<Life>().vida > 0 && score.tempo > 0) {
            switch (inimigoTipo) {
                case 1:
                    Inimigo_1();
                    break;
                default:
                    Inimigo_0();
                    break;
            }
            Rotacionar();
        }
    }

    void Inimigo_0() {
        if (!prepararTiro) {
            Seguir();
        } else {
            if (Time.time > ShootNext) {
                ShootNext = Time.time + ShootTime;
                if (gun.BulletSpawn_side.Length > 0) {
                    if (multiSingleShoot) {
                        gun.ShootSingle();
                        multiSingleShoot = false;
                    } else {
                        gun.ShootMulti();
                        multiSingleShoot = true;
                    }
                } else {
                    gun.ShootSingle();
                }
            }
        }
    }
    void Inimigo_1() {
        Seguir();
    }

    void Seguir() {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidade * Time.deltaTime);
    }
    void Rotacionar() {
        transform.up = (transform.position - new Vector3(player.transform.position.x, player.transform.position.y, 0));
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (inimigoTipo == 0) {
            if (other.gameObject.tag == "Range") {
                prepararTiro = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (inimigoTipo == 0) {
            if (other.gameObject.tag == "Range") {
                prepararTiro = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (inimigoTipo == 1) {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Navio") {
                this.GetComponent<Life>().vida -= 20;
                other.gameObject.GetComponent<Life>().vida -= 20;
                var explosion = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
            }
        }
    }
}
