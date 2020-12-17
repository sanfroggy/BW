using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChangeTipTextOnDisable : MonoBehaviour
{
    public string tip;
    public float displayTime;
    // Start is called before the first frame update
    // Update is called once per frame
    void OnDisable()
    {
        TipHandler TP = GameObject.Find("UIHandler").GetComponent<TipHandler>();
        TP.ChangeTipText(tip);
        TP.DisplayTip(displayTime);
    }
}
