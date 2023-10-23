using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Yonet : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public int SelectedCharacter;
    public TMP_InputField input_Create;
    public TMP_InputField input_Join;
    public GameObject Mage;
    public GameObject Warrior;
    public GameObject Priest;
    public GameObject PriestTwo;
    public UnityEngine.UI.Button Btn1;
    public FixedJoystick joystick;
    //public static CanvasManager Instance { get; private set; }
    //public Transform CanvasTransform { get; private set; }


    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
        if (PhotonNetwork.IsConnected)
        { int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
            Debug.Log("baglanti kuruldu");
            if (selectedCharacter == 0)
            {
                PhotonNetwork.Instantiate(PriestTwo.name, Vector3.zero, Quaternion.identity);
            }
            if (selectedCharacter == 1)
            {
                PhotonNetwork.Instantiate(Priest.name, Vector3.zero, Quaternion.identity);
            }
            if (selectedCharacter == 2)
            {
                PhotonNetwork.Instantiate(Warrior.name, Vector3.zero, Quaternion.identity);
            }
            if (selectedCharacter==3)
            {
                PhotonNetwork.Instantiate(Mage.name, Vector3.zero, Quaternion.identity);
            }
            //PhotonNetwork.Instantiate(joystick.name, new Vector3((float)282.22, (float)-190.15, 0), Quaternion.identity);
        }
    }
    private void Awake()
    {
        // Klonlanan karakterlerin içindeki scriptte Button referansýný güncelle
        // Örneðin, bu koda baþka bir script veya klonlama iþlemi sýrasýnda eriþebilirsiniz.
        Btn1 = GetComponentInChildren<UnityEngine.UI.Button>();
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
    //    GameObject kup = PhotonNetwork.Instantiate("kup", Vector3.zero, Quaternion.identity, 0, null);
    //    //GameObject joy = PhotonNetwork.Instantiate("FixedJoystick", new Vector3((float)126.2, (float)100.2, 0), Quaternion.identity, 0, null);
    //    //joy.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
    //    Debug.Log("asd");

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
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(input_Create.text);

    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(input_Join.text);
    }
    public void JoinRoomList(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Map1");
        if (SelectedCharacter==3)
        {
            PhotonNetwork.Instantiate(Mage.name, Vector3.zero, Quaternion.identity);
        }
        //GameObject kup = PhotonNetwork.Instantiate("kup", Vector3.zero, Quaternion.identity, 0, null);
    }
}
