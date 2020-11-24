using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T GetInstance
    {
        get{return instance;}
    }

    protected virtual void Awake()
    {
        instance = this as T;
    }
}
