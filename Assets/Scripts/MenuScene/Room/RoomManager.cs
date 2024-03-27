using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
   [SerializeField] private RoomListUIController _roomListUIController;
   [SerializeField] private Room _room;
   [SerializeField] private List<Room> _roomList  = new List<Room>();
   private bool _alreadyCreatedRoom = false;

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

   public void CreateAndAddRoom(){
      if(_alreadyCreatedRoom){
         return;
      }

      Room newRoom = Instantiate(_room);
      newRoom.RoomName.text = "Test";

      if(_roomList.Contains(newRoom) == false){
         _roomList.Add(newRoom);
      }
   }

   public void RemoveRoom(){

   }

   public void ClearRoom(){
      
   }
}
