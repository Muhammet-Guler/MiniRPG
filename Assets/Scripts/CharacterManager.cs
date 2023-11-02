using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
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
    public CharacterFactory characterFactory=new CharacterFactory();
    public Mage mageCharacter;
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

        mageCharacter = new Mage();
    }
    public void Update()
    {
        mageCharacter = GameObject.Find("Mage").GetComponent<Mage>();
    }
    //public void NextOption()
    //{
    //    SelectedCharacter++;
    //    if (SelectedCharacter >= characterDB.characters.Length)
    //    {
    //        SelectedCharacter = 0;
    //    }
    //    ChangeCharacter(SelectedCharacter);
    //    Save();
    //    characterDB.getAllcharacters();
    //}
    //public void BackOption()
    //{
    //    SelectedCharacter--;
    //    if (SelectedCharacter < 0)
    //    {
    //        SelectedCharacter = characterDB.characters.Length-1;
    //    }
    //    ChangeCharacter(SelectedCharacter);
    //    Save();
    //}
    //private void ChangeCharacter(int SelectedCharacter)
    //{
    //    Character character=characterDB.GetCharacter(SelectedCharacter);
    //    artworkSprite.sprite = character.characterSprite;
    //    nameText.text = character.characterName;
    //}
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
    public void LockedCharacter()
    {
        string[] selectableCharacters=characterFactory.getSelectableCharacters();
        //Debug.Log(selectableCharacters);
        for (int i = 0; i < selectableCharacters.Length; i++)
        {
            if (SelectedCharacter==i)
            {
                characterButtons[i].interactable = true;
                Debug.Log("MageCharacter:"+mageCharacter);
                //ICharacter character = characterFactory.CreateCharacter();
                //Debug.Log("character:"+character.ToString());

            }
            else { 
            characterButtons[i].interactable = false;
            }
        }
    }
}
