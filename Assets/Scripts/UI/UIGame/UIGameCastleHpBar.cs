using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameCastleHpBar : MonoBehaviour
{
    private float hpAmount;

    private float castleHp;

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
        hpText.text = castleHp.ToString();
    }


    public void SetValues(float curHp, float maxHp)
    {
        castleHp = curHp;
        hpAmount = curHp / maxHp;
        print(hpAmount);
        Init();
    }


}

