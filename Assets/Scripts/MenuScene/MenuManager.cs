using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MenuManager : MonoBehaviour{
    public static MenuManager Instance;
    [SerializeField] private RoomListManager _roomListManager;
    [SerializeField] private SettingManager _settingManager;
 
    public void Awake(){
        Instance = this;
    }

    public void SetUpRoomListActive(bool isTrue){
        _roomListManager.ShowRoomList(isTrue);
        _roomListManager.ShouldPopulateRooms(isTrue);
    }

    public void SetSettingActive(bool isShown){
        _settingManager.ShowSettings(isShown);
    }
}
