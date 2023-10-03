using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDatabase characterDB;
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
    private void UpdateCharacter(int SelectedOption)
    {
        Character character = characterDB.GetCharacter(SelectedOption);
        artworkSprite.sprite = character.characterSprite;
    }
    private void Load()
    {
        SelectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
