using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[System.Serializable]
public abstract class Character:MonoBehaviourPun
{
    private int index;
    public string characterName;
    public Sprite characterSprite;
    public int Health;
    public float Range;
    public float Speed;
    public int Damage;
    public int AttackPower;
    public int Defence;
    public string Description;
    public string instantieName;
    public Character characterType;

    public CharacterDatabase database;


    public abstract void skillOne();

    public abstract void skillTwo();
    public abstract void skillThree();
    public abstract void skillFour();
    public abstract void skillFive();
    public abstract void AttackDamage();
    public abstract void RecieveDamage();
    public Object CreateCharacter()
    {
        int SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        SelectedCharacter = 0;
        if (SelectedCharacter==0) 
        {
            Debug.Log(characterType);
            characterType =new PriestTwo();
        }
        else if (SelectedCharacter == 1)
        {
            characterType = new Priest();
        }
        else if (SelectedCharacter == 2)
        {
            characterType = new Warrior();
        }
        else if (SelectedCharacter == 3)
        {
            characterType = new Mage();
        }
        return characterType;
    }
}

