using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.TextCore.Text;

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
    public Mage character;
    //public static CanvasManager Instance { get; private set; }
    //public Transform CanvasTransform { get; private set; }


    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
        if (PhotonNetwork.IsConnected)
        {
            string selectedCharacter = PlayerPrefs.GetString("selectedCharacter");
            if (selectedCharacter == "PriestTwo")
            {
                PhotonNetwork.Instantiate(PriestTwo.name, Vector3.zero, Quaternion.identity);
            }
            if (selectedCharacter == "Priest")
            {
                PhotonNetwork.Instantiate(Priest.name, Vector3.zero, Quaternion.identity);
            }
            if (selectedCharacter == "Warrior")
            {
                PhotonNetwork.Instantiate(Warrior.name, Vector3.zero, Quaternion.identity);
            }
            if (selectedCharacter == "Mage")
            {
                PhotonNetwork.Instantiate(Mage.name, Vector3.zero, Quaternion.identity);
            }
            character.Health = 100;
            Debug.Log(character.Health);
            Debug.Log("start calisti");
        }
    }
    private void Awake()
    {
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
        
    }
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
        Debug.Log("input create:" + input_Create.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(input_Join.text);
        Debug.Log("input join:"+input_Join.text);
    }
    public void JoinRoomInList(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
        Debug.Log("roomName:" + roomName);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("CharacterAndSkillSelection");
    }
}
