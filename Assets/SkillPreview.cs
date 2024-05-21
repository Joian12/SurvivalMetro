using UnityEngine;
using UnityEngine.UI;

public class SkillPreview : MonoBehaviour
{
    [SerializeField] private Text _skillName;
    [SerializeField] private Image _skillImage;
    [SerializeField] private Skill _skill;

    public void SetSkillName(string skillName) {
        _skillName.text = skillName;
    }

    public void SetSkillImage(Image skillImage) {
        if (skillImage == null) {
            return;
        }
        
        _skillImage = skillImage;
    }

    public void SetSkill(Skill skill)
    {
        if (skill == null) {
            return;
        }

        _skill = skill;
    }

    public void ChooseSkill() {
        if (_skill == null) {
            return;
        }
        
        PlayerSkillHelper.AddSkillToPlayer(_skill );
    }
}
