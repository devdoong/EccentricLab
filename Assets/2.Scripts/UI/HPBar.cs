using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider hpBar;
    public Text hpText;


    // Update is called once per frame
    void Update()
    {
        transform.position = Managers.Player.transform.position;
        hpBar.value = Managers.HP.HP / Managers.HP.MaxHP;
        hpText.text = Managers.HP.HP.ToString();
    }
}
