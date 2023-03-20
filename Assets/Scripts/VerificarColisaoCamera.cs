using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarColisaoCamera : MonoBehaviour
{
    public bool colidiu = false;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "MainCamera") {
            colidiu = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "MainCamera") {
            colidiu = false;
        }
    }


}
