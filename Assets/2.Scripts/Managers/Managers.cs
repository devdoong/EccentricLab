                                                                                                                                                using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static bool s_initialized = false;

    //�ӽ�
    

    #region Managers
    PoolManager _pool = new PoolManager();
    public static PoolManager Pool { get { return Instance?._pool; } }
    #endregion

    #region Controller
    ProjectileController _projectile = new ProjectileController();
    public static ProjectileController Projectile { get { return Instance?._projectile; } }
    #endregion

    #region �ӽ�
    public Transform player;
    public GameObject enemy;
    public static Transform Player { get { return Instance?.player; } }
    public static GameObject Enemy { get { return Instance?.enemy; } }
    #endregion

    public static Managers Instance
    {
        get
        {
            if (s_initialized == false)//���������� ������
            {
                s_initialized = true;

                GameObject go = GameObject.Find("@MainManager"); //���θŴ��� ã�Ƽ�
                if (go == null) //@MainManager�� ��ã������
                {
                    go = new GameObject() { name = "@MainManager" }; //���� �ְ�
                    go.AddComponent<Managers>(); //������Ʈ�� �߰�
                }

                DontDestroyOnLoad(go); //���̵��Ҷ� �ı� �ȵǵ��� ����
                s_instance = go.GetComponent<Managers>(); //Managers.cs �����
            }

            return s_instance; //Managers ����
        }
    }

    private void Start()
    {
        _pool.Init();
    }

    public GameObject InstantiatePrefab(GameObject prefab,Transform transform)
    {
        return Instantiate(prefab, transform);
    }

}
