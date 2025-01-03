using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ProjectileController : MonoBehaviour
{
    static string prefabAddress = "BasicArrow"; // Addressables���� ������ �ּ�
    static GameObject arrowPrefab;
    private Transform shootPoint;
    static GameObject arrowClone;
    private float arrowSpeed = 20.0f;

    private void Start()
    {
        LoadPrefab(prefabAddress);
        shootPoint = transform.Find("ArrowShootPoint");

    }
    private void LoadPrefab(string address) //��巹������ ������ �ε�
    {
        Addressables.LoadAssetAsync<GameObject>(address).Completed += OnPrefabLoaded;
    }

    private void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            arrowPrefab = handle.Result; // ������ �ν��Ͻ�ȭ
            Debug.Log("������ �ε� ����: " + arrowPrefab.name);
        }
        else
        {
            Debug.LogError("������ �ε� ����: " + handle.OperationException);
        }
    }


    public void Shoot()
    {
        // ȭ�� ����
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
    }
    
}
