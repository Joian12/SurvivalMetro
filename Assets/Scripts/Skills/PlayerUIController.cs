using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private Button[] skillButtons;

    public void SetSkills(UnityAction<int> onSkillButtonClick)
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            int index = i; 
            skillButtons[i].onClick.AddListener(() => onSkillButtonClick(index));
        }
    }

    public void RemoveSkills()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            skillButtons[i].onClick.RemoveAllListeners();
        }
    }
}
