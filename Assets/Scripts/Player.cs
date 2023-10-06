using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    private int SelectedCharacter = 0;
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
    }
    private void ChangeCharacter(int SelectedCharacter)
    {
        Character character = characterDB.GetCharacters(SelectedCharacter);
        artworkSprite.sprite = character.characterSprite;
    }
    private void Load()
    {
        SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
    }
}
