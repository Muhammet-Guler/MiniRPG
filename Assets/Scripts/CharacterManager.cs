using JetBrains.Annotations;
using Photon.Pun;
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


public class CharacterManager : MonoBehaviourPunCallbacks
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
    public UnityEngine.UI.Image rivalSprite;
    public static ICharacter icharacter;
    public GameManager gameManager;
    private bool player1Ready = false;
    private bool player2Ready = false;
    public AllSkills allSkills;
    public static List<ISkill> selectedSkillList = new List<ISkill>();
    public UnityEngine.UI.Image[] selectedSkillImage;
    void Start()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            Color skillButtonColor = skillButtons[i].image.color;
            skillButtonColor.a = 0f;
            skillButtons[i].image.color = skillButtonColor;
        }
    }

    public void Update()
    {

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
        icharacter = characterFactory.CreateCharacter();
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
