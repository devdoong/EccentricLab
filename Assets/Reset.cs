using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private void OnDisable()
    {
        Managers.RandomSkill.list_keys.Clear();
        Managers.RandomSkill.Init();

    }

    private void OnEnable()
    {
    }
}
