using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillSettings : MonoBehaviour
{
    public static PlayerSkillSettings current;
    
    [SerializeField] private PlayerInfo _playerInfoSkill;
    
    [SerializeField] private List<Skill> _availableSkills = new List<Skill>(); // skills from shop will be added here
    private List<Skill> _inUsedSkills = new List<Skill>();

    [SerializeField] private SkillPreview _skillPreviewToInstantiate;
    
    [SerializeField] private Transform _availableSkillContainer;
    [SerializeField] private Transform _skillInUseContainer;

    private void Awake()
    {
        current = this;
    }

    private void OnEnable()
    {
        PopulateAvailablePreviewSkills();
    }

    private void OnDisable()
    {
        
    }

    public void AddToUsableSkill(Skill skill) {
        _playerInfoSkill.TryToAddSkill(skill);
        PopulateSkillListInUse(skill);
    }

    private void PopulateSkillListInUse(Skill skill) {
        if (_inUsedSkills.Contains(skill)) {
            return;
        }
        
        _inUsedSkills.Add(skill);
        
        ResetPopulateSkillListInUse();

        for (int i = 0; i < _inUsedSkills.Count; i++)
        {
            SkillPreview newSkillpreview = Instantiate(_skillPreviewToInstantiate);
            newSkillpreview.transform.SetParent(_skillInUseContainer, false);
            
            newSkillpreview.SetSkillName(_inUsedSkills[i]._skillName);
            newSkillpreview.SetSkillImage(_inUsedSkills[i]._skillImage);
            newSkillpreview.SetSkill(_inUsedSkills[i]);
        }
    }

    private void ResetPopulateSkillListInUse() {
        var childCount = _skillInUseContainer.childCount;

        for (int i = 0; i < childCount; i++) {
            var childTransform = _skillInUseContainer.transform.GetChild(i);
            Destroy(childTransform.gameObject);
        }
        Debug.Log(childCount);
    }

    private void PopulateAvailablePreviewSkills() {
        ResetAvailablePreviewSkillList();

        for (int i = 0; i < _availableSkills.Count; i++)
        {
            SkillPreview newSkillpreview = Instantiate(_skillPreviewToInstantiate);
            newSkillpreview.transform.SetParent(_availableSkillContainer, false);
            
            newSkillpreview.SetSkillName(_availableSkills[i]._skillName);
            newSkillpreview.SetSkillImage(_availableSkills[i]._skillImage);
            newSkillpreview.SetSkill(_availableSkills[i]);

        }
    }

    private void ResetAvailablePreviewSkillList() {
        var childCount = _availableSkillContainer.childCount;

        for (int i = 0; i < childCount; i++) {
           var childTransform = _availableSkillContainer.transform.GetChild(i);
           Destroy(childTransform.gameObject);
        }
        Debug.Log(childCount);
    }
}
