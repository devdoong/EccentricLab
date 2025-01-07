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

    #region Ǯ���� ���� ����
    GameObject[] prefabs; //������ ��������.
    List<GameObject>[] pools;
    #endregion

    GameObject pool; //���̷�Ű �󿡼� Ǯ�� ������ ���� �θ�

    public void Init()
    {
        #region Ǯ�� ����
        prefabs = new GameObject[1];
        prefabs[0]= Managers.Enemy;//�ӽ�
        pools = new List<GameObject>[prefabs.Length]; //��� Ǯ���� �ʿ��Ѱ�. -> ��ϵ� ������ ��ŭ
        for (int i = 0; i < pools.Length; i++)  //Ǯ�� ������ִ� �۾�.
            pools[i] = new List<GameObject>();
        #endregion

        pool = GameObject.Find("@Pool");


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
            select = Managers.Instance.InstantiatePrefab(prefabs[index], pool.transform) ; //���� �������� �����ؼ�
            pools[index].Add(select); //�ش� ������ Ǯ���ٰ� �־���
        }


        return select;
    }
}
