//创建一个可以浏览所有房间列表的窗口
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomListManager : MonoBehaviourPunCallbacks
{
    public GameObject roomNamePrefab;
    public Transform roomListCotent;

    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        //当房间信息发生变化时，添加或者删除房间
        for (int i = 0; i < roomListCotent.childCount; i++) {
            
            if (roomListCotent.GetChild(i).gameObject.GetComponentInChildren<Text>().text == roomList[i].Name) {
                Destroy(roomListCotent.GetChild(i).gameObject);
                if (roomList[i].PlayerCount == 0) {
                    roomList.Remove(roomList[i]);
                }
            }
        }
        foreach (var room in roomList) {
            GameObject newRoom = Instantiate(roomNamePrefab, roomListCotent.position, Quaternion.identity);
            newRoom.GetComponentInChildren<Text>().text = room.Name + "  " + room.PlayerCount + " " + "Player(s)";
            newRoom.transform.SetParent(roomListCotent);
        
        }
    }
}
