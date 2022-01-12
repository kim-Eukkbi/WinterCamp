using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameCastleHpBar : MonoBehaviour
{
    private float hpAmount = 1;

    private float castleMaxHp = 100;

    private Slider hpSlider;
    private Text hpText;

    void Start()
    {
        hpSlider = GameObject.Find("Hpbar").GetComponent<Slider>();
        hpText = GameObject.Find("HPText").GetComponent<Text>();
        Init();
    }

    void Init()
    {
        hpSlider.value = hpAmount;
        hpText.text = castleMaxHp.ToString();
    }


}

