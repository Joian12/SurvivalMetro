using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class NetworkRoomPlayerHandler : NetworkRoomPlayer
{
   public override void OnClientEnterRoom()
   {
      CmdChangeReadyState(true);
   }

   public override void OnClientExitRoom()
   {
      CmdChangeReadyState(false);
   }
}
