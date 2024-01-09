using JetBrains.Annotations;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class CharacterManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public UnityEngine.UI.Button[] characterButtons;
    public UnityEngine.UI.Button lockedButton;
    public UnityEngine.UI.Button lockedSkillButton;
    public UnityEngine.UI.Button[] skillButtons;
    public string selectedCharacter;
    public GameObject Mage;
    public GameObject Warrior;
    public GameObject Priest;
    public GameObject PriestTwo;
    public CharacterFactory characterFactory;
    public UnityEngine.UI.Text nickName;
    public UnityEngine.UI.Button readyButton;
    public float currentCountdown=3f;
    public UnityEngine.UI.Text countText;
    public GameObject panel;
    public SkillFactory skillFactory;
    public static ICharacter icharacter;
    public GameManager gameManager;
    private bool player1Ready = false;
    private bool player2Ready = false;
    public AllSkills allSkills;
    public static List<ISkill> selectedSkillList = new List<ISkill>();
    public UnityEngine.UI.Image[] selectedSkillImage;
    public GameObject playerImage;
    public Teams Teams;
    public GameObject canvasPrefab;
    public UnityEngine.UI.Image[] playerImages;
    Photon.Realtime.Player player;
    public GameObject TeamsObject;
    public GameObject TeamsClone;
    public GameObject obj;
    public string characterName;
    void Start()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            Color skillButtonColor = skillButtons[i].image.color;
            skillButtonColor.a = 0f;
            skillButtons[i].image.color = skillButtonColor;
        }
        Teams= FindObjectOfType<Teams>();
        if (PhotonNetwork.IsMasterClient)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "CharacterAndSkillSelection")
            {
                PhotonNetwork.Instantiate(TeamsObject.name, Vector3.zero, Quaternion.identity);
            }
        }
        TeamsClone = GameObject.Find("Teams(Clone)");
        if (photonView.IsMine)
        {
            // Senkronizasyonu sadece lokal oyuncu baþlatmalý
            photonView.RPC("SyncList", RpcTarget.AllBuffered, TeamsClone.GetComponent<Teams>().Human.ToArray());
        }
    }

    public void Update()
    {
        //if (!photonView.IsMine)
        //{
        //    playerImage.sprite = gameObject.GetComponent<ICharacter>().characterSprite;
        //}
            TeamsClone = GameObject.Find("Teams(Clone)");
        //for (int i = 0; i < Teams.GetComponent<Teams>().Human.Count; i++)
        //{

        //    //Debug.Log(Teams.GetComponent<Teams>().Human[i].characterType);

        //}
    }

    public void selectCharacter()
    {


        if (icharacter != null)
        {
            Destroy(icharacter);
        }
        UnityEngine.UI.Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent< UnityEngine.UI.Button>();

        if (clickedButton != null)
        {
            string buttonText = clickedButton.GetComponentInChildren<Text>().text;
            selectedCharacter = buttonText;
            PlayerPrefs.SetString("selectedCharacter", selectedCharacter);

            for (int i = 0; i < characterButtons.Length; i++)
            {
                Color characterButtonColor = characterButtons[i].image.color;
                characterButtonColor.a = 0.5f;
                characterButtons[i].image.color = characterButtonColor;
                if (clickedButton.name== characterButtons[i].name)
                {
                    Color buttonColor = clickedButton.image.color;
                    buttonColor.a = 1f;
                    clickedButton.image.color = buttonColor;
                }
            }
        }

    }
    public void selectSkill()
    {
        UnityEngine.UI.Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<UnityEngine.UI.Button>();

        if (clickedButton != null)
        {
            selectedSkillList.Add(icharacter.skillList[int.Parse(clickedButton.GetComponentInChildren<Text>().text)]);
            Debug.Log(":skill"+ int.Parse(clickedButton.GetComponentInChildren<Text>().text));
            selectedSkillImage[0].sprite = Resources.Load<Sprite>(selectedSkillList[selectedSkillList.Count-1].skillSprite);
            selectedSkillImage[1].sprite = Resources.Load<Sprite>(selectedSkillList[selectedSkillList.Count - 2].skillSprite);
            selectedSkillImage[2].sprite = Resources.Load<Sprite>(selectedSkillList[selectedSkillList.Count - 3].skillSprite);
        }

    }
    public void lockCharacterButtons()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            Color skillButtonColor = skillButtons[i].image.color;
            skillButtonColor.a = 1f;
            skillButtons[i].image.color = skillButtonColor;
        }
        for (int i = 0; i < characterButtons.Length; i++)
        {
            if (characterButtons[i].name == selectedCharacter)
            {
                characterButtons[i].interactable = true;
            }
            else
            {
                characterButtons[i].interactable = false;
            }
        }
        lockedButton.interactable = false;
        icharacter = characterFactory.CreateCharacter();
        ICharacter character = characterFactory.icharacter;
        skillFactory.addCharacterSkills(icharacter);
        for (int j = 0; j < AllSkills.Skillist.Count; j++)
        {
            skillButtons[j].image.sprite = Resources.Load<Sprite>(icharacter.skillList[j].skillSprite);
        }
    }
    public void skillLock()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            skillButtons[i].interactable = false;
        }
        lockedSkillButton.interactable = false;

    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        string opponentNickname = newPlayer.NickName;
        DisplayOpponentNickname(opponentNickname);
    }
    public void DisplayOpponentNickname(string opponentNickname)
    {
        nickName.text = opponentNickname;

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {

            Debug.Log(PhotonNetwork.PlayerList[i].NickName);
        }

    }
    public void OnReadyButtonClick()
    {
        // SetPlayerReady();
        SceneManager.LoadScene(2);
    }

    void SetPlayerReady()
    {
        int localPlayerNumber = PhotonNetwork.LocalPlayer.ActorNumber;

        photonView.RPC("PlayerReady", RpcTarget.AllBuffered, localPlayerNumber);
    }
    [PunRPC]
    public void PlayerReady(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Ready = true;
        }
        else if (playerNumber == 2)
        {
            player2Ready = true;
        }
        if (lockedButton.interactable == false)
        {
            if (player1Ready && player2Ready)
            {
                 photonView.RPC("StartGame", RpcTarget.AllBuffered);
            }
        }
    }

    [PunRPC]
    void StartGame()
    {
        panel.SetActive(true);
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {

            while (currentCountdown > 0)
            {
                countText.text = currentCountdown.ToString("F0");
                yield return new WaitForSeconds(1f);
                currentCountdown--;
            }
            photonView.RPC("ChangeScene", RpcTarget.AllBuffered);
        
    }

    [PunRPC]
    void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }  

    public void AddMemberHuman()
    {
        //player.SetTeam(PunTeams.Team.red);
        //Teams.Human = PunTeams.PlayersPerTeam.GetTeam(PunTeams.Team.red);
        string selectedCharacter = PlayerPrefs.GetString("selectedCharacter");
        if (selectedCharacter == "PriestTwo")
        {
            obj = PhotonNetwork.Instantiate(PriestTwo.name, Vector3.zero, Quaternion.identity);
            //GameObject Teams = GameObject.Find("Teams(Clone)");
            //TeamsClone.GetComponent<Teams>().Human.Add(obj.GetComponent<ICharacter>());
            //photonView.RPC("SyncData", RpcTarget.OthersBuffered, obj.GetComponent<ICharacter>());

             //Teams.Human.Add(obj.GetComponent<ICharacter>());
            obj.name = PhotonNetwork.NickName;
            obj.SetActive(false);

            characterName = obj.name;
        }
        if (selectedCharacter == "Priest")
        {
            obj = PhotonNetwork.Instantiate(Priest.name, Vector3.zero, Quaternion.identity);
            //GameObject Teams = GameObject.Find("Teams(Clone)");
            //TeamsClone.GetComponent<Teams>().Human.Add(obj.GetComponent<ICharacter>());
            AddElement(obj.GetComponent<ICharacter>());
            //photonView.RPC("SyncData", RpcTarget.OthersBuffered, obj.GetComponent<ICharacter>());
            obj.name = PhotonNetwork.NickName;
            obj.SetActive(false);
            characterName = obj.name;
        }
        if (selectedCharacter == "Warrior")
        {
            obj = PhotonNetwork.Instantiate(Warrior.name, Vector3.zero, Quaternion.identity);
            //GameObject Teams = GameObject.Find("Teams(Clone)");
            //TeamsClone.GetComponent<Teams>().Human.Add(obj.GetComponent<ICharacter>());
            AddElement(obj.GetComponent<ICharacter>());
            //photonView.RPC("SyncData", RpcTarget.OthersBuffered, obj.GetComponent<ICharacter>());
            obj.name = PhotonNetwork.NickName;
            obj.SetActive(false);
            characterName = obj.name;
        }
        if (selectedCharacter == "Mage")    
        {
            obj = PhotonNetwork.Instantiate(Mage.name, Vector3.zero, Quaternion.identity);
            //GameObject Teams = GameObject.Find("Teams(Clone)");
            //TeamsClone.GetComponent<Teams>().Human.Add(obj.GetComponent<ICharacter>());
            AddElement(obj.GetComponent<ICharacter>());
            //photonView.RPC("SyncData", RpcTarget.OthersBuffered, obj.GetComponent<ICharacter>());
            obj.name = PhotonNetwork.NickName;
            obj.SetActive(false);
            characterName = obj.name;
        }
        for (int i = 0; i < Teams.Human.Count; i++)
        {
            GameObject Teams = GameObject.Find("Teams(Clone)");
            playerImages[i].sprite = Resources.Load<Sprite>(Teams.GetComponent<Teams>().Human[i].characterSprite);
            
        }
        //for (int i = 0; i < ; i++)
        //{

        //}
        //Teams.Human.Add(icharacter);
        //if (!photonView.IsMine)
        //{
        //}

        //for (int i = 0; i < Teams.Human.Count; i++)
        //{
        //    playerImages[i].sprite = Resources.Load<Sprite>(Teams.Human[i].characterSprite);
        //}
        //if (!photonView.IsMine)
        //{
        //    PhotonNetwork.Instantiate(playerImage.name, Vector3.zero, Quaternion.identity);
        //    UnityEngine.UI.Image playerImageComponent = playerImage.GetComponent<UnityEngine.UI.Image>();
        //    GameObject.Find("PlayerImage1(Clone)").transform.transform.SetParent(canvasPrefab.transform);
        //    playerImageComponent.rectTransform.sizeDelta = new Vector2(400, 75);
        //    Vector3 playerImagePosition = new Vector3((float)500, 1200, 0);
        //    playerImagePosition.y -= 50;
        //    GameObject.Find("PlayerImage1(Clone)").transform.position = playerImagePosition;
        //}
    }
    [PunRPC]
    private void SyncList()
    {
        //TeamsClone.GetComponent<Teams>().Human.Clear();
        TeamsClone.GetComponent<Teams>().Human = new List<ICharacter>();
    }

    public void AddElement(ICharacter newElement)
    {
        //if (photonView.IsMine)
        //{
        //    if (TeamsClone.GetComponent<Teams>().Human == null || TeamsClone.GetComponent<Teams>().Human.Count == 0)
        //    {
        //        photonView.RPC("SyncList", RpcTarget.AllBuffered, TeamsClone.GetComponent<Teams>().Human.ToArray());
        //    }
        //    TeamsClone.GetComponent<Teams>().Human.Add(newElement);

        //    // Deðiþikliði tüm oyunculara bildir
        //    photonView.RPC("SyncList", RpcTarget.AllBuffered, TeamsClone.GetComponent<Teams>().Human.ToArray());
        //}
    }
    [PunRPC]
    private void SyncData(ICharacter character)
    {
        // Senkronize edilen veriyi diðer oyuncular üzerinde güncelle
        TeamsClone.GetComponent<Teams>().Human.Add(character);
    }
    public void OrcButton()
    {
        Teams.AddTeamOrc(icharacter);
        //player.SetTeam(PunTeams.Team.blue);
    }
    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(Teams.Human);

    //    }
    //    else
    //    {
    //        Teams.Human=(List<ICharacter>)stream.ReceiveNext();
    //    }


    //}
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //GameObject Teams = GameObject.Find("Teams(Clone)");
        //Debug.Log(Teams.name);
        //if (stream.IsWriting)
        //{
        //    //// Yazma iþlemi: Senkronize edilecek listeyi yaz
        //    //// Listeyi direkt olarak gönderemeyiz, bu yüzden elemanlarý tek tek gönderiyoruz
        //    //stream.SendNext(TeamsClone.GetComponent<Teams>().Human.Count);

        //    //foreach (ICharacter item in TeamsClone.GetComponent<Teams>().Human)
        //    //{
        //    //    stream.SendNext(item);
        //    //}
        //    Debug.Log("if");
        //        stream.SendNext(TeamsClone.GetComponent<Teams>().Human);
            
            
        //}
        //else
        //{
        //    //// Okuma iþlemi: Senkronize edilen listeyi oku
        //    //int listCount = (int)stream.ReceiveNext();

        //    //TeamsClone.GetComponent<Teams>().Human.Clear(); // Önceki listeyi temizle

        //    //for (int i = 0; i < listCount; i++)
        //    //{
        //    //    ICharacter item = (ICharacter)stream.ReceiveNext();
        //    //    TeamsClone.GetComponent<Teams>().Human.Add(item);
        //    //    Debug.Log(item);
        //    //}
        //        TeamsClone.GetComponent<Teams>().Human = (List<ICharacter>)stream.ReceiveNext();
        //    Debug.Log(TeamsClone.GetComponent<Teams>().Human[1]);
            
        //    Debug.Log("else");
        //}
        if (stream.IsWriting)
        {
            // Senkronize edilecek veriyi yazma (gönderme)
            stream.SendNext(characterName);
        }
        else
        {
            // Senkronize edilen veriyi okuma (alma)
            //TeamsClone.GetComponent<Teams>().Human = new List<ICharacter>((ICharacter[])stream.ReceiveNext());
            //TeamsClone.GetComponent<Teams>().Human.Clear();
            //TeamsClone.GetComponent<Teams>().Human.AddRange((List<ICharacter>)stream.ReceiveNext());
            characterName=(string)stream.ReceiveNext();
            Debug.Log(characterName);
        }

    }
    //public void Serialize(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    // Senkronize edilecek veriyi yazma (gönderme)
    //    stream.SendNext(TeamsClone.GetComponent<Teams>().Human.ToArray());
    //}

    //public void Deserialize(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    // Senkronize edilen veriyi okuma (alma)
    //    TeamsClone.GetComponent<Teams>().Human = (List<ICharacter>)stream.ReceiveNext();
    //}
}
