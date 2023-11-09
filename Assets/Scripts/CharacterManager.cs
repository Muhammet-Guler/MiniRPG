using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;


public class CharacterManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public CharacterDatabase characterDB;
    public Text nameText;
    public SpriteRenderer artworkSprite;
    public Button[] characterButtons;
    public Button lockedButton;

    private int SelectedCharacter = 0;
    private string selectedCharacter;
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
    void Start()
    {
        if (!PlayerPrefs.HasKey("SelectedCharacter"))
        {
            SelectedCharacter = 0;
        }
        else
        {
            Load();
        }
        //ChangeCharacter(SelectedCharacter);
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
    private void Load()
    {
        SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }

    public void ActiveButton(int i)
    {
        characterButtons[i].interactable = true;

    }

    public void deActiveButton(int i)
    {
        characterButtons[i].interactable = false;

    }


    public void selectCharacter()
    {
        for (int i = 0; i < characterButtons.Length; i++)
        {
            characterButtons[i].onClick.AddListener(()=>ActiveButton(i));
            if (selectedCharacter == "Mage")
            {
                characterButtons[i].interactable = true;

            }
            else
            {
                characterButtons[i].interactable = false;
            }
        }
        lockedButton.interactable = false;

    }

    public void SelectPriestTwo()
    {
        SelectedCharacter = 0;
        Save();
    }
    public void SelectPriest()
    {
        SelectedCharacter = 1;
        Save();
    }
    public void SelectWarrior()
    {
        SelectedCharacter = 2;
        Save();
    }
    public void SelectMage()
    {
        SelectedCharacter = 3;
        Save();
    }
    public void lockCharacterButtons()
    {
        for (int i = 0; i < characterButtons.Length; i++)
        {
            if (SelectedCharacter == i)
            {
                characterButtons[i].interactable = true;

            }
            else
            {
                characterButtons[i].interactable = false;
            }
        }
        lockedButton.interactable = false;
    }
    public void LockedCharacter()
    {
        string[] selectableCharacters = characterFactory.getSelectableCharacters();
        //Debug.Log(selectableCharacters);
        for (int i = 0; i < selectableCharacters.Length; i++)
        {
            if (SelectedCharacter == i)
            {
                characterButtons[i].interactable = true;
                this.character = new Mage();
                Debug.Log("character:" + character);

            }
            else
            {
                characterButtons[i].interactable = false;
            }
        }
        lockedButton.interactable = false;
        skillFactory.Start();
        Debug.Log(skillFactory);
        Debug.Log("allskilList:"+skillFactory.allSkillList);
        Debug.Log("selectableSkilllList"+skillFactory.AllSelectableSkillList);

        //character.skillList.add(Iskill selectedList);
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
        }
        else
        {
            readyCount = (int)stream.ReceiveNext();
        }
    }
}
