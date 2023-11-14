using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public CharacterManager characterManager;
    public ICharacter icharacter = null;
    private string SelectedCharacter;
    public ICharacter CreateCharacter()
    {
        SelectedCharacter=PlayerPrefs.GetString("selectedCharacter");
        if (SelectedCharacter=="Mage")
        {
            icharacter = gameObject.AddComponent<Mage>();
        }
        else if (SelectedCharacter == "Priest")
        {
            icharacter = gameObject.AddComponent<Priest>();
        }
        else if (SelectedCharacter == "Warrior")
        {
            icharacter = gameObject.AddComponent<Warrior>();
        }
        else if (SelectedCharacter == "PriestTwo")
        {
            icharacter = gameObject.AddComponent<PriestTwo>();
        }
        return icharacter;
        
    }



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
