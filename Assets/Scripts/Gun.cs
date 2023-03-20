using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform[] BulletSpawn_side;
    public Transform BulletSpawn_front;
    public GameObject BulletPrefab;
    public float bulletSpeed = 10;

    public void ShootSingle() {
        var bullet = Instantiate(BulletPrefab, BulletSpawn_front.position, BulletSpawn_front.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = BulletSpawn_front.up * bulletSpeed;
    }
    public void ShootMulti() {
        for (int i = 0; i < BulletSpawn_side.Length; i++) {
            var bullet = Instantiate(BulletPrefab, BulletSpawn_side[i].position, BulletSpawn_side[i].rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = BulletSpawn_side[i].up * bulletSpeed;
        }
    }
}
