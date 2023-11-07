using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ICharacter:MonoBehaviour
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
    public List<ISkill> skillList;


    public Animator CharacterAnimation;
    
    public ICharacter()
    {
    }

    public abstract void AttackDamage();
    public abstract void RecieveDamage();
}

