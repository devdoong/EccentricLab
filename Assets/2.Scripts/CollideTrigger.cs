using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MapController
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{gameObject.name}에 플레이어 진입. 맵을 재배치.");
            ReplaceMaps(other,this.gameObject);
        }
    }
}
