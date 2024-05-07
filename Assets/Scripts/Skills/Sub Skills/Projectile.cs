using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform _target;
    public float _duration;
    
    private void OnEnable() {
        StartCoroutine(SeekTarget());
    }

    private void OnDisable()
    {
        // return to pool
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private IEnumerator SeekTarget()
    {
        float startTime = Time.time;
        float elapsedTime = 0f;
        
        while (elapsedTime < _duration)
        {
            elapsedTime = Time.time - startTime;
            
            yield return null;
        }
        
        gameObject.SetActive(false);
    }
}
