using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

[DisallowMultipleComponent]
public class MenuManager : MonoBehaviour{
    public static MenuManager Instance;
    [SerializeField] private SettingManager _settingManager;
    [SerializeField] private NetworkManager _networkManager;
 
    public void Awake(){
        Instance = this;
        _networkManager = FindObjectOfType<NetworkManager>();
    }

    public void SetSettingActive(bool isShown){
        _settingManager.ShowSettings(isShown);
    }
}
