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
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            SelectedCharacter = 0;
        }
        else
        {
            Load();
        }
        ChangeCharacter(SelectedCharacter);
    }
    public void NextOption()
    {
        SelectedCharacter++;
        if (SelectedCharacter >= characterDB.CharacterCount)
        {
            SelectedCharacter = 0;
        }
        ChangeCharacter(SelectedCharacter);
        Save();
    }
    public void BackOption()
    {
        SelectedCharacter--;
        if (SelectedCharacter < 0)
        {
            SelectedCharacter = characterDB.CharacterCount-1;
        }
        ChangeCharacter(SelectedCharacter);
        Save();
    }
    private void ChangeCharacter(int SelectedCharacter)
    {
        Character character=characterDB.GetCharacters(SelectedCharacter);
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
        SceneManager.LoadScene(1);
    }
}
