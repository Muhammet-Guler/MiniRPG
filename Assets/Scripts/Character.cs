using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Character:MonoBehaviour
{
    public string characterName;
    public Sprite characterSprite;
    public int Health;
    public float Range;
    public float Speed;
    public int Damage;
    public int AttackPower;
    public int Defence;

    public abstract void skillOne();

    public abstract void skillTwo();
    public abstract void skillThree();
    public abstract void skillFour();
    public abstract void skillFive();
    public abstract void AttackDamage();
    public abstract void RecieveDamage();
}

