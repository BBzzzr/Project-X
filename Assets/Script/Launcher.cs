//服务器连接
//Photon相关的函数可以参考Photon官网的文档
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject Name;
    public GameObject Room;
    public GameObject content;
    public InputField playName;
    public InputField roomName;

    //开始游戏时，连接服务器
    private void Start() {
        PhotonNetwork.ConnectUsingSettings();
    }
    //连接到服务器后，输入姓名
    public override void OnConnectedToMaster() {
        Name.SetActive(true);
        PhotonNetwork.JoinLobby();
    }
    //输入完姓名，加入或者创建房间
    public void PlayButton() {
        Name.SetActive(false);
        PhotonNetwork.NickName = playName.text;
        Room.SetActive(true);
        if (PhotonNetwork.InLobby) {
            content.SetActive(true);
        }
    }
    //加入或者创建房间按钮的功能实现
    public void JoinOrCreateRoom() {
        if (roomName.text.Length < 1) {
            return;
        }

        Room.SetActive(false);
        content.SetActive(false);

        RoomOptions options = new RoomOptions{ MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, default);
    }
    //跳转到创建的房间
    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel(2);
    }
}
