using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DashSkill", menuName = "Skill/Projectile")]
public class ProjectComponentSkill : Skill
{
    [SerializeField] private Projectile _projectile;
    public override IEnumerator PerformSkill(Transform transform = null, Vector3 startTransform = default, Vector3 endTransform = default)
    {
        yield return null;
    }
}

public enum ProjectileType
{
    Homing, 
    LastPoint
}
