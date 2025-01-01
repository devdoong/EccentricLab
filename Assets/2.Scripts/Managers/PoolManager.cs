using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class PoolManager : MonoBehaviour
{

    public static PoolManager Instance { get; private set; }

    public GameObject[] prefabs;

    List<GameObject>[] pools;

    private void Awake()
    {

        // �̱��� �Ҵ�
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return; // �Ʒ� �ڵ� ���� ����
        }

        pools = new List<GameObject>[prefabs.Length]; //��� Ǯ���� �ʿ��Ѱ�. -> ��ϵ� ������ ��ŭ
        for (int i = 0; i < pools.Length; i++)  //Ǯ�� ������ִ� �۾�.
            pools[i] = new List<GameObject>();
    }

    public GameObject Active(int index)
    {
       
        GameObject select = null;

        foreach (GameObject go in pools[index]) //Ȱ��ȭ �ϰ��� �ϴ°� Ǯ�� �ִ°� ��ȸ
        {
            if (go.activeSelf == false) //Ȱ��ȭ���°� �ƴ϶��?
            {
                select = go; 
                select.SetActive(true); //Ȱ��ȭ
                break; //foreach Ż���ؾ���. �߰� Ȱ��ȭ x
            }
        }

        if (select == null) //���� foreach���� Ǯ ��ȸ �� �ߴµ��� null�̸� (���δ� Ȱ��ȭ ���¸�)
        {
            select = Instantiate(prefabs[index], transform); //Instantiate�Ǵ� ��ü�� ���ڽ��� �θ�� ������� transform�� �־���.
            pools[index].Add(select);
        }

        return select;
    }
}
