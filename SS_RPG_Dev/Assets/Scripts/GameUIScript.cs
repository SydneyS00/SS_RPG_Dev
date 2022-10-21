using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIScript : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    //instance
    public static GameUIScript instance;

    void Awake()
    {
        instance = this;
    }

    public void UpdateGoldText (int gold)
    {
        goldText.text = "<b>Gold:</b> " + gold;
    }
}
