using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticipantStatus : MonoBehaviour
{
    [SerializeField] private GroupCategory playerGroup;
    
    private void OnEnable()
    {
        ParticipantsManager.current.AddParticipant(this);
    }
    
    private void OnDisable()
    {
        
    }

    public void SetPlayerGroup(GroupCategory playerGroupCategory) {
        playerGroup = playerGroupCategory;
    }
}

public enum GroupCategory
{
    Group1,
    Group2,
    Group3,
    Group4,
    Group5,
    Solo,
}
