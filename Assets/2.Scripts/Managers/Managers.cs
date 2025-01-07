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

    //임시
    

    #region Managers
    PoolManager _pool = new PoolManager();
    public static PoolManager Pool { get { return Instance?._pool; } }
    #endregion

    #region Controller
    ProjectileController _projectile = new ProjectileController();
    public static ProjectileController Projectile { get { return Instance?._projectile; } }
    #endregion

    #region 임시
    public Transform player;
    public GameObject enemy;
    public static Transform Player { get { return Instance?.player; } }
    public static GameObject Enemy { get { return Instance?.enemy; } }
    #endregion

    public static Managers Instance
    {
        get
        {
            if (s_initialized == false)//생성된적이 없으면
            {
                s_initialized = true;

                GameObject go = GameObject.Find("@MainManager"); //메인매니저 찾아서
                if (go == null) //@MainManager를 못찾았으면
                {
                    go = new GameObject() { name = "@MainManager" }; //만들어서 넣고
                    go.AddComponent<Managers>(); //컴포넌트도 추가
                }

                DontDestroyOnLoad(go); //씬이동할때 파괴 안되도록 해줌
                s_instance = go.GetComponent<Managers>(); //Managers.cs 담아줌
            }

            return s_instance; //Managers 리턴
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
