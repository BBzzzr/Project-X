//创建人物
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CreateCharacter : MonoBehaviourPunCallbacks
{
    public GameObject readyButton;
    //当按下ready时创建一个人物
    public void ReadyToPlay() {
        readyButton.SetActive(false);
        PhotonNetwork.Instantiate("ruby", new Vector3(0, 0, 0), Quaternion.identity, 0);
    }
}
