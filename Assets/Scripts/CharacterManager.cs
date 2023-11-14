using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class CharacterManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public CharacterDatabase characterDB;
    public Text nameText;
    public SpriteRenderer artworkSprite;
    public UnityEngine.UI.Button[] characterButtons;
    public UnityEngine.UI.Button lockedButton;

    private int SelectedCharacter = 0;
    public string selectedCharacter;
    public GameObject UsernamePage;
    public UnityEngine.UI.Text MyUsername;
    public GameObject Mage;
    public GameObject Warrior;
    public GameObject Priest;
    public GameObject PriestTwo;
    public CharacterFactory characterFactory;
    public ICharacter character;
    public UnityEngine.UI.Text nickName;
    public UnityEngine.UI.Button readyButton;
    private int readyCount = 0;
    public int currentCountdown=10;
    public UnityEngine.UI.Text countText;
    public GameObject panel;
    public SkillFactory skillFactory;
    public UnityEngine.UI.Image rivalSprite;
    public static ICharacter icharacter;
    public GameManager gameManager;
    void Start()
    {
        if (PlayerPrefs.GetString("Username") == "" || PlayerPrefs.GetString("Username") == null)
        {
            UsernamePage.SetActive(true);
        }
        else
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("Username");
            MyUsername.text = PlayerPrefs.GetString("Username");
            UsernamePage.SetActive(false);
        }

    }

    public void Update()
    {

    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(2);
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
    public void Ready()
    {
        photonView.RPC("ReadyCount", RpcTarget.All);
        SceneManager.LoadScene(2);
    }
    [PunRPC]
    public void ReadyCount()
    {
        if (lockedButton.interactable == false)
        {
            readyCount++;
            readyButton.interactable = false;
            if (readyCount == 2)
            {
                panel.SetActive(true);
                StartCoroutine(Countdown());
            }
        }
    }
    IEnumerator Countdown()
    {
        while (currentCountdown > 0)
        {
            yield return new WaitForSeconds(1);

            currentCountdown--;
            countText.text = currentCountdown.ToString();
            if (currentCountdown == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(readyCount);
            stream.SendNext(selectedCharacter);
        }
        else
        {
            readyCount = (int)stream.ReceiveNext();
            selectedCharacter = (string)stream.ReceiveNext();
        }
    }
}
