using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DashSkill", menuName = "Skill/Projectile")]
public class ProjectComponentSkill : Skill
{
    [SerializeField] private Projectile _projectile;
    public int projectileCount = 3;
    public override IEnumerator PerformSkill(Transform player = null, Vector3 startTransform = default, Vector3 endTransform = default)
    {
        for (int i = 0; i < projectileCount; i++) {
            Projectile projectile = Instantiate(_projectile, player.position , player.rotation);
            projectile.ActivateProjectile(player);
        }
        
        yield return null;
    }
}

public enum ProjectileType
{
    Homing, 
    LastPoint
}
