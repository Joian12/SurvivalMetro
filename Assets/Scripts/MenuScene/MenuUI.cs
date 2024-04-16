using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _connecGO;
    [SerializeField] private GameObject _readyGO;
    
    [SerializeField] private TMP_InputField _ipInputField;
    [SerializeField] private Button _playButton;
    
    [SerializeField] private NetworkHandler _networkManager; //seperate this to networkhandler

    private void Awake() {
        _networkManager = FindObjectOfType<NetworkHandler>();
    }

    private void OnEnable() {
        Debug.Log("AWAKE");
        _playButton.onClick.AddListener(Play);
        Reset();
    }

    private void OnDisable() {
        _playButton.onClick.RemoveListener(Play);
        Reset();
    }

    private void Cancel() {
        Reset();
        _networkManager.StartHost();
        _connecGO.SetActive(true);
    }

    private void Play() {
        _connecGO.SetActive(false);
        _networkManager.StartHost();
        _networkManager.networkAddress = _ipInputField.text;
        _readyGO.SetActive(!NetworkClient.active);
    }

    private void Reset() {
        _connecGO.SetActive(true);
        _readyGO.SetActive(false);
    }
}
