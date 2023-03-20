using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour{

    public GameObject[] enemy;
    public GameObject[] spawnEnemy;
    float spawnTime;

    private float spawnNext = 0f;

    private void Start() {
        spawnTime = PlayerPrefs.GetFloat("SpawnShip");
    }
    void Update() {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Life>().vida > 0 && FindObjectOfType<Score>().tempo > 0) {
            Sorteio(spawnEnemy);
            Sorteio(enemy);
            if (Time.time > spawnNext) {
                spawnNext = Time.time + spawnTime;
                SpawnaInimigo(spawnEnemy);
            }
        }
    }
    void Sorteio(GameObject[] e) {
        GameObject temp_spawn;
        int rand;
        for(int i = 0; i < e.Length; i++) {
            rand = Random.Range(0, e.Length);
            temp_spawn = e[rand];
            e[rand] = e[i];
            e[i] = temp_spawn;
        }
    }

    void SpawnaInimigo(GameObject[] e) {
        for (int i = 0; i < e.Length; i++) {
            if (!e[i].GetComponent<VerificarColisaoCamera>().colidiu) {
                Instantiate(enemy[0], e[i].transform.position, e[i].transform.rotation);
                break;
            } else continue;
        }
    }

    public void ResetSpawn() {
        spawnNext = -spawnTime;
    }
}
