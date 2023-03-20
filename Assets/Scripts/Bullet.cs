using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float vida = 5;

    public GameObject ExplosionPrefab;
    Score score;
    void Awake()   {
        Destroy(gameObject, vida);
    }
    private void Start() {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != "Spawn" && collision.gameObject.tag != "MainCamera" && collision.gameObject.tag != "Range") { 
            if (collision.gameObject.tag == "Navio" || collision.gameObject.tag == "Player") {
                collision.gameObject.GetComponent<Life>().vida -= 20;
                var explosion = Instantiate(ExplosionPrefab, collision.transform.position, collision.transform.rotation);
                if (collision.GetComponent<Inimigo>()) score.score += 5;
            }
            if (collision.gameObject.tag == "ArmaMapa") {
                Destroy(collision.gameObject);
                var explosion = Instantiate(ExplosionPrefab, collision.transform.position, collision.transform.rotation);
            }
            Destroy(gameObject);
        }
    }

}
