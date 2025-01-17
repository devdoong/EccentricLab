using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ProjectileController : MonoBehaviour
{
    static string prefabAddress = "BasicArrow"; // Addressables에서 설정한 주소
    static GameObject arrowPrefab;
    public Transform[] shootPoint;
    static GameObject arrowClone;

    public float arrowDamage = 60;

    private void Start()
    {
        LoadPrefab(prefabAddress);

    }
    private void LoadPrefab(string address) //어드레서블에서 프리팹 로드
    {
        Addressables.LoadAssetAsync<GameObject>(address).Completed += OnPrefabLoaded;
    }

    private void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            arrowPrefab = handle.Result; // 프리팹 인스턴스화
        }
        
    }

    public void Shoot()
    {
        // 화살 생성

        for (int i = 0; i < Managers.SkillState.abilityLevelState["Arrow"]; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab, shootPoint[i].position, shootPoint[i].rotation);

        }

    }
    
}
