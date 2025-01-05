using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MapController
{
    /*private MapController mapController;
    void Start()
    {
        // �θ� ������Ʈ���� MapController ������Ʈ�� ã���ϴ�.
        mapController = GetComponentInParent<MapController>();

        if (mapController == null)
        {
            Debug.LogError("MapController�� ã�� �� �����ϴ�. CollideTrigger�� ������ ������Ʈ�� �θ� MapController�� �־�� �մϴ�.");
        }
    }*/
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{gameObject.name}�� �÷��̾ �����߽��ϴ�. ���� ���ġ�մϴ�.");
            ReplaceMaps(other,this.gameObject);
        }
    }
}
