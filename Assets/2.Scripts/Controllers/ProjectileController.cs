using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ProjectileController : MonoBehaviour
{
    static string prefabAddress = "BasicArrow"; // Addressables에서 설정한 주소
    static GameObject arrowPrefab;
    private Transform shootPoint;
    static GameObject arrowClone;

    [SerializeField]
    private int arrowDamage = 60;
    public int ArrowDamage { get { return arrowDamage; } }

    private void Start()
    {
        LoadPrefab(prefabAddress);
        shootPoint = transform.Find("ArrowShootPoint");

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
            Debug.Log("프리팹 로드 성공: " + arrowPrefab.name);
        }
        
    }

    public void Shoot()
    {
        // 화살 생성
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
    }
    
}
