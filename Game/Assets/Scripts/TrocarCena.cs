using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    public void MudarCena(string cena) {
        SceneManager.LoadScene(cena);
    }
}
