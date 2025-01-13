using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MapController
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ReplaceMaps(other,this.gameObject);
        }
    }
}
