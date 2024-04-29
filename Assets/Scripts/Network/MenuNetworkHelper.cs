using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNetworkHelper : MonoBehaviour
{
    [SerializeField] private NetworkHandler _networkManager; 

    private void Start() {
        _networkManager = NetworkHandler.Current;
        
    }

    private void OnDestroy()
    {
        
    }

  

    public void StartClient() {
        _networkManager.StartHost();
    }
    
    public void StopClient() {
        _networkManager.StopClient();
    }

    public int GetClientCount()
    {
        return _networkManager.clientIndex;
    }

    public void SetNetwordAddress(string networkAddress) {
        _networkManager.networkAddress = networkAddress;
    }

    public int GetRoomClientCount() {
        return _networkManager.clientIndex;
    }
}
