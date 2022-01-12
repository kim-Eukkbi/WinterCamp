using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameWaveBar : MonoBehaviour
{
    private float waveAmount = 1;

    private float waveStage = 1;

    private Slider waveSlider;
    private Text waveText;

    void Start()
    {
        waveSlider = GameObject.Find("Wavebar").GetComponent<Slider>();
        waveText = GameObject.Find("WaveText").GetComponent<Text>();
        Init();
    }

    void Init()
    {
        waveSlider.value = waveAmount;
        waveText.text = "Wave " + waveStage.ToString();
    }


}

