using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour{
    [SerializeField] private SettingUIController _settingUIController;

    public void ShowSettings(bool isShown){
        _settingUIController.gameObject.SetActive(isShown);
    }
}
