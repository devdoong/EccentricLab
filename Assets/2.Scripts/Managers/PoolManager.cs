using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.UIElements;

public class PoolManager
{

    #region 풀장을 만들 변수
    GameObject[] prefabs; //프리팹 못가져옴.
    List<GameObject>[] pools;
    #endregion

    GameObject pool; //하이러키 상에서 풀장 역할을 해줄 부모

    public void Init()
    {
        #region 풀장 생성
        prefabs = new GameObject[1];
        prefabs[0]= Managers.Enemy;//임시
        pools = new List<GameObject>[prefabs.Length]; //몇개의 풀장이 필요한가. -> 등록된 프리팹 만큼
        for (int i = 0; i < pools.Length; i++)  //풀장 만들어주는 작업.
            pools[i] = new List<GameObject>();
        #endregion

        pool = GameObject.Find("@Pool");


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
            select = Managers.Instance.InstantiatePrefab(prefabs[index], pool.transform) ; //몬스터 프리팹을 선택해서
            pools[index].Add(select); //해당 몬스터의 풀에다가 넣어줌
        }


        return select;
    }
}
