using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class Yonet : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public int SelectedCharacter;
    //public static CanvasManager Instance { get; private set; }
    //public Transform CanvasTransform { get; private set; }


    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Servere girildi");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("lobiye girildi");
        //PhotonNetwork.JoinOrCreateRoom("oda", new RoomOptions { MaxPlayers = 8, IsOpen = true, IsVisible = true }, TypedLobby.Default);
    }
    //public override void OnJoinedRoom()
    //{
    //    Debug.Log("odaya girildi");
    //    GameObject mage = PhotonNetwork.Instantiate("Mage", Vector3.zero, Quaternion.identity, 0, null);
    //    GameObject joy= PhotonNetwork.Instantiate("FixedJoystick", new Vector3((float)126.2, (float)100.2, 0), Quaternion.identity, 0, null);
    //    joy.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(),false);

    //}
    public override void OnLeftRoom()
    {
        Debug.Log("odadan cikildi");
    }
    public override void OnLeftLobby()
    {
        Debug.Log("lobiden cikildi");
    }
    public override void OnJoinRoomFailed(short returnCode,string message)
    {
        Debug.Log("Hata:Odaya girilemedi");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Hata:Herhangi bir odaya girilemedi");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Hata:Oda Kurulamadý");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("oyundan cikildi");
    }
}
