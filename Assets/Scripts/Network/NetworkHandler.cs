using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.Examples.Pong;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NetworkHandler : NetworkRoomManager
{
   public static NetworkHandler Current;
   [SerializeField] private PlayerListNetwork _playerListNetwork;
   
   public int _maxCountPlayer = 1;

   public override void Awake()
   {
      base.Awake();
      Current = this;
      _playerListNetwork.gameObject.SetActive(false);
   }
   
   public override void OnRoomServerPlayersReady()
   {
      base.OnRoomServerPlayersReady();
   }

   public override void OnClientDisconnect()
   {
      base.OnClientDisconnect();
      GlobalNetworkAction.OnClientRoomExit?.Invoke();
      _playerListNetwork.gameObject.SetActive(true);
      clientIndex--;
   }

   public override void OnServerAddPlayer(NetworkConnectionToClient conn)
   {
      // base.OnServerAddPlayer(conn);
      clientIndex++;

      if (Utils.IsSceneActive(RoomScene))
      {
         allPlayersReady = false;

         _playerListNetwork.gameObject.SetActive(true);

         //Debug.Log("NetworkRoomManager.OnServerAddPlayer playerPrefab: {roomPlayerPrefab.name}");
         GameObject newRoomGameObject = OnRoomServerCreateRoomPlayer(conn);
         if (newRoomGameObject == null)
            newRoomGameObject = Instantiate(roomPlayerPrefab.gameObject, Vector3.zero, Quaternion.identity);

         newRoomGameObject.transform.SetParent(_playerListNetwork._roomListingContainer, false);
         
         NetworkServer.AddPlayerForConnection(conn, newRoomGameObject);
      }
      else
      {
         // Late joiners not supported...should've been kicked by OnServerDisconnect
         Debug.Log($"Not in Room scene...disconnecting {conn}");
         conn.Disconnect();
      }
      
      GlobalNetworkAction.OnServerAddPlayer?.Invoke();
   }

   public override void OnClientConnect()
   {
      base.OnClientConnect();
      GlobalNetworkAction.OnServerAddPlayer?.Invoke();
   }

   public override void OnRoomClientEnter()
   {
      base.OnRoomClientEnter();
      GlobalNetworkAction.OnClientRoomEnter?.Invoke();
   }

   public override void OnRoomClientExit() {
      base.OnRoomClientExit();
      Debug.Log("NETWORK CLIENT ENTERED EXIT!!");
      GlobalNetworkAction.OnClientRoomExit?.Invoke();
   }
   
   public override void ReadyStatusChanged()
   {
      if (_maxCountPlayer == clientIndex) {
         StartCoroutine(CheckReadyToBeginDelay());
      }
      else
         allPlayersReady = false;
   }
   
   IEnumerator CheckReadyToBeginDelay()
   {
      yield return new WaitForSeconds(3);
      CheckReadyToBegin();
      _playerListNetwork.gameObject.SetActive(false);
   }
}
