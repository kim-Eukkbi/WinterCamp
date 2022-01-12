using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameWaveBar : MonoBehaviour
{
    private float amount = 0;
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
        waveSlider.value = amount;

        waveText.text = "Wave " + waveStage.ToString();
    }

    public void SetValues(float curEnemy,float maxEnemy,int curStage)
    {
        amount = curEnemy / maxEnemy;
        waveStage = curStage;
        Init();
    }


}

