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

    private int SelectedOption = 0;
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            SelectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(SelectedOption);
    }
    public void NextOption()
    {
        SelectedOption++;
        if (SelectedOption>=characterDB.CharacterCount)
        {
            SelectedOption = 0;
        }
        UpdateCharacter(SelectedOption);
        Save();
    }
    public void BackOption()
    {
        SelectedOption--;
        if (SelectedOption <0)
        {
            SelectedOption = characterDB.CharacterCount-1;
        }
        UpdateCharacter(SelectedOption);
        Save();
    }
    private void UpdateCharacter(int SelectedOption)
    {
        Character character=characterDB.GetCharacter(SelectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }
    private void Load()
    {
        SelectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption",SelectedOption);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
