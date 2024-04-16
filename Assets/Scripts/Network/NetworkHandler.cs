using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NetworkHandler : NetworkRoomManager
{
   public Transform _roomPlayerContainer;
   public GameObject _playerListingUI;
   public int _maxCountPlayer = 1;
   public int _currentCountPlayer;
   public Text maxPlayerCountText;
   public Text currentPlayerCountText;

   private void OnEnable()
   {
      _playerListingUI.SetActive(false);
      UpdatePlayerCountText();
   }

   public override void OnServerAddPlayer(NetworkConnectionToClient conn)
   {
      clientIndex++;
      _currentCountPlayer++;
      
      _playerListingUI.SetActive(true);

      if (Utils.IsSceneActive(RoomScene))
      {
         allPlayersReady = false;
         
         GameObject newRoomGameObject = OnRoomServerCreateRoomPlayer(conn);
         if (newRoomGameObject == null)
            newRoomGameObject = Instantiate(roomPlayerPrefab.gameObject, Vector3.zero, Quaternion.identity);

         newRoomGameObject.transform.SetParent(_roomPlayerContainer, false);
         NetworkServer.AddPlayerForConnection(conn, newRoomGameObject);
      }
      else
      {
         Debug.Log($"Not in Room scene...disconnecting {conn}");
         conn.Disconnect();
      }
      
      UpdatePlayerCountText();
   }

   private void UpdatePlayerCountText()
   {
      maxPlayerCountText.text = _maxCountPlayer.ToString(); // parse it
      currentPlayerCountText.text = _currentCountPlayer.ToString(); // parse it
   }
   
   public override void OnRoomServerPlayersReady()
   {
      // all players are readyToBegin, start the game
      Debug.Log("Changed room!");
      
      _playerListingUI.SetActive(false);
      
      ServerChangeScene(GameplayScene);
   }

   public override void OnClientDisconnect() {
      _currentCountPlayer--;
      UpdatePlayerCountText();
   }

   public override void OnRoomClientExit()
   {
      Debug.Log("NETWORK CLIENT ENTERED EXIT!!");
      _playerListingUI.SetActive(false);
   }
   
   public override void ReadyStatusChanged()
   {
      int CurrentPlayers = 0;
      int ReadyPlayers = 0;
   
      foreach (NetworkRoomPlayer item in roomSlots)
      {
         if (item != null)
         {
            CurrentPlayers++;
            if (item.readyToBegin)
               ReadyPlayers++;
         }
      }
   
      if (_maxCountPlayer == _currentCountPlayer) {
         CheckReadyToBegin();
      }
      else
         allPlayersReady = false;
   }
}
