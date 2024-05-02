using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
   [SerializeField] private PlayerUIController _playerUIController;
   [SerializeField] private DashComponentSkill _dashComponentSkill;

   private void Start()
   {
      _playerUIController = FindObjectOfType<PlayerUIController>();
      _playerUIController.SetSkills(OnSkillButtonClick);
   }

   private void OnDestroy()
   {
      _playerUIController.RemoveSkills();
   }
   
   private void OnSkillButtonClick(int index)
   {
      switch (index)
      {
         case 0:
            PerformSkill_1();
            break;
         case 1:
            PerformSkill_2();
            break;
         case 2:
            PerformSkill_3();
            break;
         default:
            Debug.LogWarning("Invalid skill button index: " + index);
            break;
      }
   }
   
   private void PerformSkill_1()
   {
      Debug.Log("PERFORMED SKILL 1");

      Vector3 startTransform = transform.position;
      Vector3 endTransform = transform.position + Vector3.forward * 5f; 

      StartCoroutine(_dashComponentSkill.PerformDash(transform, startTransform, endTransform));
   }

   
   private void PerformSkill_2()
   {
      Debug.Log("PERFORMED SKILL 2");
   }
   
   private void PerformSkill_3()
   {
      Debug.Log("PERFORMED SKILL 3");
   }
}
