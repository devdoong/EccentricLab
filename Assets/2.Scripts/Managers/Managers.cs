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

    /*PoolManager _pool = new PoolManager();
    public static PoolManager Pool { get { return Instance?._pool; } }*/


    public static Managers Instance
    {
        get
        {
            if (s_initialized == false)
            {
                s_initialized = true;

                GameObject go = GameObject.Find("@MainManager");
                if (go == null)
                {
                    go = new GameObject() { name = "@MainManager" };
                    go.AddComponent<Managers>();
                }

                DontDestroyOnLoad(go);
                s_instance = go.GetComponent<Managers>();
            }

            return s_instance;
        }
    }
}
