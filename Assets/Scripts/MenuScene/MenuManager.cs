using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MenuManager : MonoBehaviour{
    public static MenuManager Instance;
    // [SerializeField] private RoomManager _roomManager;
    [SerializeField] private SettingManager _settingManager;
 
    public void Awake(){
        Instance = this;
    }

    // public void SetUpRoomListActive(bool isTrue){
    //     _roomManager.ShowRoomList(isTrue);
    //     _roomManager.ShouldPopulateRooms(isTrue);
    // }

    public void SetSettingActive(bool isShown){
        _settingManager.ShowSettings(isShown);
    }
}
