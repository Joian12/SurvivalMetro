using System.Collections;
using UnityEngine;

public enum SkillCategory
{
    Passive,
    Active
}

public enum SkillAbilities
{
    Dash, 
    Shield,
    PowerUp,
    Projectile,
}

public class Skill : ScriptableObject
{
    public string _skillName;
    public SkillCategory _skillCategory;
    public SkillAbilities _skillAbilities;

    public virtual IEnumerator PerformSkill(Transform transform = null, Vector3 startTransform = default, Vector3 endTransform = default)
    {
        yield return null;
    } 
}

