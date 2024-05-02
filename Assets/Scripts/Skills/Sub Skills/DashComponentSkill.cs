using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "DashSkill", menuName = "Skill/Dash")]
public class DashComponentSkill : Skill
{
    public float _duration;
    public int _damage;
    
    public bool _canTeleport;
    public bool _canDamage;

    public IEnumerator PerformDash(Transform transform, Vector3 startTransform, Vector3 endTransform)
    {
        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            float t = elapsedTime / _duration;
            transform.position = Vector3.Lerp(startTransform, endTransform, t);
             
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endTransform;
    }
}