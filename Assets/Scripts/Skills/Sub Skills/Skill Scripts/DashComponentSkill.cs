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

    [SerializeField] private GameObject _playerContainer;

    public override IEnumerator PerformSkill(Transform transform = null, Vector3 startTransform = default, Vector3 endTransform = default)
    {
        float startTime = Time.time;
        float elapsedTime = 0f;

        if (_canTeleport == false)
        {
            while (elapsedTime < _duration)
            {
                float t = Mathf.Clamp01((Time.time - startTime) / _duration);
                transform.position = Vector3.Lerp(startTransform, endTransform, t);

                elapsedTime = Time.time - startTime;
            
                PlayerContainerActive(isActive:true);
                yield return null;
            }
        }

        PlayerContainerActive(isActive:false);
        transform.position = endTransform;
    }

    private void PlayerContainerActive(bool isActive) {
        if (_playerContainer == null) {
            return;
        }
        _playerContainer.SetActive(isActive);
    }

}
