using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _score;

    //public event System.Action<int> onScoreUpdated = delegate { };
    [SerializeField] private UnityEvent<int> onScoreUpdated;
    public void AddScore(int increment)
    { 
        _score += increment;
        onScoreUpdated?.Invoke( _score );
    }
}
