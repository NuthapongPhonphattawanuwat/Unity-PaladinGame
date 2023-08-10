using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{ 
    private static T _instance; 
    public static T instance => _instance;
    
    protected virtual void Awake() 
    { 
        _instance = this as T;
    }
}
