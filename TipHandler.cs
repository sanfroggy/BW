using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TipHandler : MonoBehaviour
{
    private GameObject tips;
    private Text tipText;
    // Start is called before the first frame update
    void Start()
    {
        tips = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        tipText = tips.GetComponent<Text>();
        Invoke("TurnTextOff", 6.5f);
    }

    // Update is called once per frame
    public void TurnTextOff() {
        tips.SetActive(false);
    }

    public void TurnTextOn()
    {
        tips.SetActive(true);
    }

    public void ChangeTipText(string newText)
    {
        tipText.text = newText;
    }

    public void DisplayTip(float time)
    {
        TurnTextOn();
        
        Invoke("TurnTextOff", time);
    }
}
