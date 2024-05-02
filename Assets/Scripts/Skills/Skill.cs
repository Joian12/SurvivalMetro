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
}

public interface ISkillable
{
    public void PerformSkill();
}

