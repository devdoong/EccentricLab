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

        // 싱글턴 할당
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return; // 아래 코드 실행 막기
        }

        pools = new List<GameObject>[prefabs.Length]; //몇개의 풀장이 필요한가. -> 등록된 프리팹 만큼
        for (int i = 0; i < pools.Length; i++)  //풀장 만들어주는 작업.
            pools[i] = new List<GameObject>();
    }

    public GameObject Active(int index)
    {
       
        GameObject select = null;

        foreach (GameObject go in pools[index]) //활성화 하고자 하는게 풀에 있는가 순회
        {
            if (go.activeSelf == false) //활성화상태가 아니라면?
            {
                select = go; 
                select.SetActive(true); //활성화
                break; //foreach 탈출해야함. 추가 활성화 x
            }
        }

        if (select == null) //위에 foreach에서 풀 순회 다 했는데도 null이면 (전부다 활성화 상태면)
        {
            select = Instantiate(prefabs[index], transform); //Instantiate되는 객체를 내자신을 부모로 삼기위해 transform을 넣어줌.
            pools[index].Add(select);
        }

        return select;
    }
}
