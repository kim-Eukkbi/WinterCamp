using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRootGame : MonoBehaviour
{
    void Awake()
    {
        GameSceneClass.gUiRootGame = this;
    }

    public void TestFunc()
    {
        print("call UIRootGame");
    }
}
