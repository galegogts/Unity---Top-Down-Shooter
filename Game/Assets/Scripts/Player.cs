using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 2f;
    public float rotacao = 10f;
    float x;
    float y;
    
    Gun gun;
    Vector3 posicaoInicial;
    Quaternion rotacaoInicial;
    Score score;

    private void Start() {
        gun = GetComponent<Gun>();
        score = FindObjectOfType<Score>();

        posicaoInicial = transform.position;
        rotacaoInicial = transform.rotation;

    }

    void Update() {
        if (this.GetComponent<Life>().vida > 0 && score.tempo > 0) {
            Move();
            Shoot();
        }
    }

    void Shoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            gun.ShootSingle();
        } else if (Input.GetKeyDown(KeyCode.LeftControl)) {
            gun.ShootMulti();
        }
    }

    void Move() {
        x = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, (-x * rotacao) * Time.deltaTime, Space.Self);

        y = Input.GetAxis("Vertical");
        if (y >= 0) transform.Translate(new Vector3(0, (-y * velocidade) * Time.deltaTime, 0));
        else transform.Translate(new Vector3(0, (-y * (velocidade / 3)) * Time.deltaTime, 0));
    }

    public void SetPosicaoInicial() {
        transform.position = posicaoInicial;
        transform.rotation = rotacaoInicial;
    }
}
