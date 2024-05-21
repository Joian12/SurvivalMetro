public static class PlayerSkillHelper
{
    public static void AddSkillToPlayer(Skill skill) {
        PlayerSkillSettings.current.AddToUsableSkill(skill);
    }
}
