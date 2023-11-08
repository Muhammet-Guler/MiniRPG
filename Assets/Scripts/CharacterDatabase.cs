using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public ICharacter[] characters;
    public ICharacter GetCharacter(int index) { 
        return characters[index];
    }

    public string[] getAllcharacters()
    {
        string[] characters = {"Mage","Priest","Warrior","PriestTwo"};
        return characters;
    }
}
