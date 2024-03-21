using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour{
     [SerializeField] private GameObject _home;
     [SerializeField] private RoomListUIController _roomListingController;
     [SerializeField] private SettingUIController _settingsController;

     public void ShowRoomList(bool isShown){
          _roomListingController.gameObject.SetActive(isShown);
     }

     public void ShowSettings(bool isShown){
          _settingsController.gameObject.SetActive(isShown);
     }
}
