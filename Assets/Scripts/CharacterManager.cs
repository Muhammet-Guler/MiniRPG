using JetBrains.Annotations;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class CharacterManager : MonoBehaviourPunCallbacks
{
    public CharacterDatabase characterDB;
    public Text nameText;
    public SpriteRenderer artworkSprite;
    public UnityEngine.UI.Button[] characterButtons;
    public UnityEngine.UI.Button lockedButton;
    public UnityEngine.UI.Button[] skillButtons;

    private int SelectedCharacter = 0;
    public string selectedCharacter;
    public GameObject Mage;
    public GameObject Warrior;
    public GameObject Priest;
    public GameObject PriestTwo;
    public CharacterFactory characterFactory;
    public ICharacter character;
    public UnityEngine.UI.Text nickName;
    public UnityEngine.UI.Button readyButton;
    private int readyCount = 0;
    public float currentCountdown=3f;
    public UnityEngine.UI.Text countText;
    public GameObject panel;
    public SkillFactory skillFactory;
    public UnityEngine.UI.Image rivalSprite;
    public static ICharacter icharacter;
    public GameManager gameManager;
    private bool player1Ready = false;
    private bool player2Ready = false;
    public AllSkills allSkills;
    void Start()
    {

    }

    public void Update()
    {

    }

    public void CharacterLayoutButtons()
    {
        
    }

    public void selectCharacter()
    {
        UnityEngine.UI.Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent< UnityEngine.UI.Button>();

        if (clickedButton != null)
        {
            string buttonText = clickedButton.GetComponentInChildren<Text>().text;
            selectedCharacter = buttonText;
            PlayerPrefs.SetString("selectedCharacter", selectedCharacter);
            Debug.Log("selectedcharacter:" + selectedCharacter);
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
        if (clickedButton.name=="Mage")
        {
            for (int i = 0; i < skillButtons.Length-2; i++)
            {
                skillButtons[i].image.sprite = allSkills.mageSkillSprites[i];
                Text buttonText = skillButtons[i].GetComponentInChildren<Text>();
                buttonText.text = "";
                allSkills.skillInfo.text = allSkills.mageSkillInformation[i];
                // skillInfo.text =iSkill.description;
            }
        }
        else if (clickedButton.name == "Priest")
        {
            for (int i = 0; i < skillButtons.Length-2; i++)
            {
                skillButtons[i].image.sprite = allSkills.priestSkillSprites[i];
                Text buttonText = skillButtons[i].GetComponentInChildren<Text>();
                buttonText.text = "";
                allSkills.skillInfo.text = allSkills.priestSkillInformation[i];
            }
        }
        else if (clickedButton.name == "Warrior")
        {
            for (int i = 0; i < skillButtons.Length-2; i++)
            {
                skillButtons[i].image.sprite = allSkills.warriorSkillSprites[i];
                Text buttonText = skillButtons[i].GetComponentInChildren<Text>();
                buttonText.text = "";
                allSkills.skillInfo.text = allSkills.warriorSkillInformation[i];
            }
        }
        else if (clickedButton.name == "PriestTwo")
        {
            for (int i = 0; i < skillButtons.Length-2; i++)
            {
                skillButtons[i].image.sprite = allSkills.priestTwoSkillSprites[i];
                Text buttonText = skillButtons[i].GetComponentInChildren<Text>();
                buttonText.text = "";
                allSkills.skillInfo.text = allSkills.priestTwoSkillInformation[i];
            }
        }

    }
    public void lockCharacterButtons()
    {
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
            if (!photonView.IsMine)
            {
                selectedCharacter = PlayerPrefs.GetString("selectedCharacter");
                if (characterButtons[i].GetComponentInChildren<Text>().ToString() == selectedCharacter)
                {
                    rivalSprite.sprite = characterButtons[i].GetComponent<Sprite>();
                }
            }
        }
        lockedButton.interactable = false;
        icharacter= characterFactory.CreateCharacter();
        Debug.Log(icharacter.instantieName);

    }
    public void skillLock(ISkill skill)
    {
        character.skillList.Add(skill);
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
            //readyButton.interactable = false;
            if (player1Ready && player2Ready)
            {
                if (photonView.IsMine)
                {
                    photonView.RPC("StartGame", RpcTarget.AllBuffered);
                }
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
    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(selectedCharacter);
    //    }
    //    else
    //    {
    //        selectedCharacter = (string)stream.ReceiveNext();
    //    }
    //}
}
