using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    public Sprite sprite;
    public void WarriorClass()
    {
        characterName = "Warrior";
        characterSprite = sprite;
        Health = 100;
        Range = 13;
        Speed = 3;
        Damage = 9;
        AttackPower = 10;
        Defence = 10;
    }
    public override void skillOne()
    {

    }
    public override void skillTwo()
    {

    }
    public override void skillThree()
    {

    }
    public override void skillFour()
    {

    }
    public override void skillFive()
    {

    }
    public override void AttackDamage()
    {

    }
    public override void RecieveDamage()
    {

    }
}
