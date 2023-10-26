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

    private int SelectedCharacter = 0;
    private string selectedCharacter;
    public GameObject UsernamePage;
    public UnityEngine.UI.Text MyUsername;
    public GameObject Mage;
    public GameObject Warrior;
    public GameObject Priest;
    public GameObject PriestTwo;
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
        ChangeCharacter(SelectedCharacter);
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
    public void NextOption()
    {
        SelectedCharacter++;
        if (SelectedCharacter >= characterDB.characters.Length)
        {
            SelectedCharacter = 0;
        }
        ChangeCharacter(SelectedCharacter);
        Save();
        characterDB.getAllcharacters();
    }
    public void BackOption()
    {
        SelectedCharacter--;
        if (SelectedCharacter < 0)
        {
            SelectedCharacter = characterDB.characters.Length-1;
        }
        ChangeCharacter(SelectedCharacter);
        Save();
    }
    private void ChangeCharacter(int SelectedCharacter)
    {
        Character character=characterDB.GetCharacter(SelectedCharacter);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
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
    public void SelectCharacter()
    {
        
    }
}
