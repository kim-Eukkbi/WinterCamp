using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameSkillBar : MonoBehaviour
{
    private float skillAmount =0;
    private float skillcostStack = 0;


    private Slider skillCostSlider;
    private Text coststack;

    void Start()
    {
        skillCostSlider = GameObject.Find("SkillCostBar").GetComponent<Slider>();
        coststack = GameObject.Find("CostText").GetComponent<Text>();
        StartCoroutine(UpdateCost());
    }

    public IEnumerator UpdateCost()
    {
        while(true)
        {
            yield return null;
            skillAmount += .0005f;
            skillCostSlider.value = Mathf.Clamp(skillAmount,0,1);
            if(skillcostStack / 10 <= skillAmount)
            {
                skillcostStack++;
                coststack.text = skillcostStack.ToString();
            }
        }
    }


}
