using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider xpBar;
    public Text xpText;

    void Update()
    {
        xpBar.value = Managers.Level.MyExp / Managers.Level.MaxExp;
        xpText.text = "Lv."+Managers.Level.Level.ToString();

    }
}
