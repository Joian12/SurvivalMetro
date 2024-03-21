using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MenuManager : MonoBehaviour{
    public static MenuManager Instance;
    [SerializeField] private MenuController _menuController;

    public void Awake(){
        Instance = this;
    }

    public void SetRoomListingActive(bool isShown){
        _menuController.ShowRoomList(isShown);
    }

    public void SetSettingActive(bool isShown){
        _menuController.ShowSettings(isShown);
    }
}
