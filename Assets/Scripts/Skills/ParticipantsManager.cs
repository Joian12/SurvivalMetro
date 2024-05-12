using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticipantsManager : MonoBehaviour
{
    public static ParticipantsManager current;
    
    [SerializeField] private List<ParticipantStatus> _allParticipants = new List<ParticipantStatus>();

    private void Awake()
    {
        current = this;
    }

    public void AddParticipant(ParticipantStatus participantStatus) {
        _allParticipants.Add(participantStatus);
    }
    
}
