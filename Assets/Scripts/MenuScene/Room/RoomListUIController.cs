using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListUIController : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private void Awake(){
        _container.gameObject.SetActive(false);
    }

    public void ShowRoomList(bool isShown){
        _container.gameObject.SetActive(isShown);
    }
}
