using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MapController
{
    /*private MapController mapController;
    void Start()
    {
        // 부모 오브젝트에서 MapController 컴포넌트를 찾습니다.
        mapController = GetComponentInParent<MapController>();

        if (mapController == null)
        {
            Debug.LogError("MapController를 찾을 수 없습니다. CollideTrigger가 부착된 오브젝트의 부모에 MapController가 있어야 합니다.");
        }
    }*/
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{gameObject.name}에 플레이어가 진입했습니다. 맵을 재배치합니다.");
            ReplaceMaps(other,this.gameObject);
        }
    }
}
