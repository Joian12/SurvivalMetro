using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PortalType{
    Home,
    RoomListing,
    Settings
}

public class TriggerObject : MonoBehaviour{
    public PortalType _portalType;

    private void OnTriggerEnter(Collider other){
        ActivatePortalEntry(isShown:true);
    }

    private void OnTriggerExit(Collider other){
        ActivatePortalEntry(isShown:false);
    }

    private void ActivatePortalEntry(bool isShown){
         switch(_portalType){
            case PortalType.Home:
                break;
            case PortalType.RoomListing:
                MenuManager.Instance.SetRoomListingActive(isShown);
                break;
            case PortalType.Settings:
                MenuManager.Instance.SetSettingActive(isShown);
                break;
        }
    }
}
