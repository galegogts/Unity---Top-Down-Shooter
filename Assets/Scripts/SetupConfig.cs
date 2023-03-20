using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetupConfig : MonoBehaviour
{
    public Slider SpawnShipSlider;
    public Slider GameTimeSlider;
    public Slider VolumeSlider;

    public GameObject spawnShipTxt;
    public GameObject gameTimetTxt;
    public GameObject VolumeTxt;

    float spawnShip;
    float gameTime;
    float volume;

    private void Start() {
        if (PlayerPrefs.GetFloat("SpawnShip") > 0) SpawnShipSlider.value = PlayerPrefs.GetFloat("SpawnShip");
        if (PlayerPrefs.GetFloat("GameTime") > 0) GameTimeSlider.value = PlayerPrefs.GetFloat("GameTime");
        if (PlayerPrefs.GetFloat("Volume") > -1) VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }
    private void Update() {
        spawnShip = SpawnShipSlider.value;
        gameTime = GameTimeSlider.value;
        volume = VolumeSlider.value;
        PlayerPrefs.SetFloat("SpawnShip", spawnShip);
        PlayerPrefs.SetFloat("GameTime", gameTime);
        PlayerPrefs.SetFloat("Volume", volume);
        spawnShipTxt.GetComponent<TextMeshProUGUI>().text = ((int)(spawnShip)).ToString();
        gameTimetTxt.GetComponent<TextMeshProUGUI>().text = ((int)(gameTime)).ToString();
        VolumeTxt.GetComponent<TextMeshProUGUI>().text = ((int)(volume)).ToString();
        AudioListener.volume = volume / 100;
    }
}
