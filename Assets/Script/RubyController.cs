//人物的控制文件
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class RubyController : MonoBehaviourPun
{
    // Start is called before the first frame update
    public Text nameText;
    private void Awake() {
        if (photonView.IsMine) {
            nameText.text = PhotonNetwork.NickName;
        } else {
            nameText.text = photonView.Owner.NickName;
        }
    }
    void Start()
    {
        
    }
    //当人物被创建时，添加人物的姓名在人物下方

    // Update is called once per frame
    void Update()
    {
        //确保操作的是自己的人物而不是别的玩家的人物
        if (!photonView.IsMine && PhotonNetwork.IsConnected) {
            return;
        }
        //获取玩家输入信息并实现移动的操作
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + 0.03f*horizontal;
        position.y = position.y + 0.03f*vertical;
        transform.position = position;
    }
}
