using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform _target;
    public float _speed;
    public float _distance; 
    private Vector3 startTransform;
    private Vector3 endTransform;
    
    public void ActivateProjectile(Transform playerTrans) {
        StartCoroutine(SeekTarget());
        startTransform = playerTrans.position + new Vector3(0,1f,0);
        endTransform = playerTrans.position + (playerTrans.forward * _distance);
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
        
        while (elapsedTime < _speed)
        {
            float t = Mathf.Clamp01((Time.time - startTime) / _speed);
            transform.position = Vector3.Lerp(startTransform, endTransform, t);

            elapsedTime = Time.time - startTime;
            yield return null;
        }
        
        Destroy(gameObject); // create pooling please
    }
}
