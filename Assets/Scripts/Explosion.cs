using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public bool conluirExplosao = false;
    // Update is called once per frame
    void Update() {
        if(conluirExplosao) Destroy(this.gameObject);
    }
}
