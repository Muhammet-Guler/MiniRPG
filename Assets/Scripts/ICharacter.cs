using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[System.Serializable]
public abstract class ICharacter:MonoBehaviourPun
{ 
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


    public Animator CharacterAnimation;

    public abstract void AttackDamage();
    public abstract void RecieveDamage();
}

