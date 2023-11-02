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
        string[] subfolders = Directory.GetDirectories(Application.dataPath+"/Characters");

        foreach (string subfolderPath in subfolders)
        {
            string subfolderName = Path.GetFileName(subfolderPath);
            Debug.Log("Character klasör isimleri: " + subfolderName);
        }
        return subfolders;
    }
}
