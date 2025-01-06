using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MapController
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{gameObject.name}�� �÷��̾� ����. ���� ���ġ.");
            ReplaceMaps(other,this.gameObject);
        }
    }
}
