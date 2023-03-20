using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score : MonoBehaviour
{
    public int score;

    float tempoTotal;
    public float tempo = 0;

    public GameObject panel;
    public GameObject Scoretext;
    public GameObject Tempotext;
    GameObject player;

    public VerificarColisaoCamera spawnInicial;

    public Slider VolumeSlider;
    public GameObject VolumeTxt;
    float volume;

    private void Start() {
        VolumeSlider.value = PlayerPrefs.GetFloat("Volume");

        tempoTotal = PlayerPrefs.GetFloat("GameTime");
        ResetarTempoScore();
        player = FindObjectOfType<Player>().gameObject;
    }
    void Update() {
        volume = VolumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);
        VolumeTxt.GetComponent<TextMeshProUGUI>().text = ((int)(volume)).ToString();
        AudioListener.volume = volume/100;

        if (tempo > 0 && player.GetComponent<Life>().vida > 0) tempo -= Time.deltaTime;
        else panel.SetActive(true);

        Tempotext.GetComponent<TextMeshProUGUI>().text = ((int)(tempo)).ToString();
        Tempotext.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ((int)(tempo)).ToString();

        Scoretext.GetComponent<TextMeshProUGUI>().text = score.ToString();
        Scoretext.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    void ResetarTempoScore() {
        panel.SetActive(false);
        tempo = tempoTotal;
        score = 0;
    }

    public void ResartGame() {
        ResetarTempoScore();
        spawnInicial.colidiu = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<Life>().vida = player.GetComponent<Life>().GetVidaTotal();
        player.GetComponent<Life>().vivo = true;
        player.GetComponent<Player>().SetPosicaoInicial();
        FindObjectOfType<SpawnInimigo>().ResetSpawn();
        GameObject[] objs = FindObjectsOfType<GameObject>();
        for(int i = 0; i < objs.Length; i++) {
            if (objs[i].tag == "Navio" || objs[i].tag == "bullet" || objs[i].tag == "explosao") Destroy(objs[i]);
        }
    }
}
