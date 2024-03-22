using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListManager : MonoBehaviour
{
   [SerializeField] private RoomListUIController _roomListUIController;
   [SerializeField] private Room _rooms;
   [SerializeField] private List<Room> _roomList  = new List<Room>();

   public void ShowRoomList(bool isShown){
     _roomListUIController.ShowRoomList(isShown);
   }

   public void ShouldPopulateRooms(bool isPopulating){
      if(isPopulating == false){
         Depopulate();
         return;
      }

      // Populate Room
   }

   private void Depopulate(){
      // Depopulate Room
   }
}
