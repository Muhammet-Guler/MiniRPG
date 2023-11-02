using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    public CharacterDatabase characterDB;
    private string selectedCharacter = "Mage";
    public CharacterManager characterManager;
    public CharacterSkills characterSkills;
    public Mage character;
    public ICharacter CreateCharacter()
    {
        this.character = new Mage();
        Debug.Log("mage:"+character);
        if (character == null)
        {
            Debug.LogError("Mage sýnýfý oluþturulamadý.");
        }
        return this.character;
        
    }
    public string[] getSelectableCharacters()
    {
        Debug.Log("getAllCharacters:" + characterDB.getAllcharacters());
        return characterDB.getAllcharacters();
    }
    public void setSelectedCharacter(string selectedcharacter="Mage")
    {
        this.selectedCharacter = selectedcharacter;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
