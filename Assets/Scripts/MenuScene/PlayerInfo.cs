using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Player")]
public class PlayerInfo : ScriptableObject
{
    [SerializeField] private List<Skill> _skill;

    public void TryToAddSkill(Skill skill) {
        if (skill == null) {
            return;
        }

        if (_skill.Count >= 3) {
            return;
        }

        if (_skill.Contains(skill)) {
            return;
        }
        
        _skill.Add(skill);
    }

    public void ResetPlayerSkill()
    {
        _skill.Clear();
    }
}
