using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// seperate all player list  to playerlistnetwork class; and use command
/// </summary>
public class MenuUI : MonoBehaviour
{
    public static MenuUI Current;
    [SerializeField] private Text testNumber;
    [SerializeField] private GameObject _connecGO;
    [SerializeField] private GameObject _readyGO;
    
    [SerializeField] private TMP_InputField _ipInputField;
    [SerializeField] private Button _playButton;
    [SerializeField] private MenuNetworkHelper _menuNetworkHelper;
    // [SerializeField] private PlayerListNetwork _playerListNetwork;


    private void Awake() {
        Current = this;
    }

    private void OnEnable() {
        _playButton.onClick.AddListener(Play);
        GlobalNetworkAction.OnServerAddPlayer += OnServerAddPlayer;
        GlobalNetworkAction.OnClientRoomExit += OnClientRoomExit;
        GlobalNetworkAction.OnClientRoomEnter += OnClientRoomEnter;
        Reset();
    }

    private void OnDisable() {
        _playButton.onClick.RemoveListener(Play);
        GlobalNetworkAction.OnServerAddPlayer -= OnServerAddPlayer;
        GlobalNetworkAction.OnClientRoomExit -= OnClientRoomExit;
        GlobalNetworkAction.OnClientRoomEnter -= OnClientRoomEnter;

        Reset();
    }
    
    private void OnServerAddPlayer() {
        // testNumber.text = _menuNetworkHelper.GetClientCount().ToString();
    }

    private void OnClientRoomEnter() {
        // PopulateAvatarList();
    }

    private void OnClientRoomExit() {
        Debug.Log("EXIT -1");
    }

    private void Cancel() {
        Reset();
        _menuNetworkHelper.StopClient();
        _connecGO.SetActive(true);
    }

    private void Play() {
        _connecGO.SetActive(false);
        _menuNetworkHelper.SetNetwordAddress(_ipInputField.text); 
        
        _menuNetworkHelper.StartClient();

        _readyGO.SetActive(!NetworkClient.active);
    }

   

    private void Reset() {
        _connecGO.SetActive(true);
        _readyGO.SetActive(false);
    }
}
