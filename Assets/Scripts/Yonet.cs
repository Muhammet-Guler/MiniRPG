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
    public UnityEngine.UI.Toggle odaGorunurluk;
    public UnityEngine.UI.Text maxPlayers;
    public UnityEngine.UI.Text[] playerNicknameText;
    public int maxPlayerNumber;


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
        }
    }
    private void Awake()
    {
        Btn1 = GetComponentInChildren<UnityEngine.UI.Button>();
    }

    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "CharacterAndSkillSelection")
        {
            UpdatePlayerList();
        }
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
        SceneManager.LoadScene(6);
    }
    public void CreateRoom()
    {

        RoomOptions roomOptions = new RoomOptions()
        {
            MaxPlayers = (byte)int.Parse(maxPlayers.text),
            IsVisible = odaGorunurluk.isOn,

        };

        PhotonNetwork.CreateRoom(input_Create.text,roomOptions);
        Debug.Log("input create:" + input_Create.text);
        maxPlayerNumber = int.Parse(maxPlayers.text);
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
        Debug.Log("odaya girildi"+" "+PhotonNetwork.CurrentRoom.Name+" "+PhotonNetwork.NickName+" Max Oyuncu: "+PhotonNetwork.CurrentRoom.MaxPlayers+" görünürlük: "+odaGorunurluk.isOn);
    }
    void UpdatePlayerList()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            playerNicknameText[i].text = PhotonNetwork.PlayerList[i].NickName.ToString();
        }
        
    }
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        UpdatePlayerList();
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        UpdatePlayerList();
    }
}
