using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public Character[] characters;
    public Character GetCharacter(int index) { 
        return characters[index];
    }
    public Character[] getAllcharacters()
    {
        return characters;
    }
}
