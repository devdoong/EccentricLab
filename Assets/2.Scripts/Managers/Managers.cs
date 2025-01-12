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
    LevelManager _level = new LevelManager();
    public static LevelManager Level { get { return Instance?._level; } }
    HPManager _hp = new HPManager();
    public static HPManager HP { get { return Instance?._hp; } }
    DamageManager _damage = new DamageManager();   
    public static DamageManager Damage { get { return Instance?._damage; } }
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

    #region Managers 시작 작업
    private void Awake()
    {
        if (s_instance != null && s_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        s_instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public static Managers Instance
    {
        get
        {
            return s_instance;
        }
    }
    #endregion



    private void Start()
    {
        _pool.Init();
        _damage.Init();
    }

    public GameObject InstantiatePrefab(GameObject prefab,Transform transform)
    {
        return Instantiate(prefab, transform);
    }

}
