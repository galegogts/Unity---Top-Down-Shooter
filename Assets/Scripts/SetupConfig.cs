using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetupConfig : MonoBehaviour
{
    public Slider SpawnShipSlider;
    public Slider GameTimeSlider;

    public GameObject spawnShipTxt;
    public GameObject gameTimetTxt;

    float spawnShip;
    float gameTime;

    private void Start() {
        if (PlayerPrefs.GetFloat("SpawnShip") > 0) SpawnShipSlider.value = PlayerPrefs.GetFloat("SpawnShip");
        if (PlayerPrefs.GetFloat("GameTime") > 0) GameTimeSlider.value = PlayerPrefs.GetFloat("GameTime");
    }
    private void Update() {
        spawnShip = SpawnShipSlider.value;
        gameTime = GameTimeSlider.value;
        PlayerPrefs.SetFloat("SpawnShip", spawnShip);
        PlayerPrefs.SetFloat("GameTime", gameTime);
        spawnShipTxt.GetComponent<TextMeshProUGUI>().text = ((int)(spawnShip)).ToString();
        gameTimetTxt.GetComponent<TextMeshProUGUI>().text = ((int)(gameTime)).ToString();
    }
}
