using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : Character
{
    public Sprite sprite;
    public void PriestClass()
    {
        characterName = "Priest";
        characterSprite = sprite;
        Health = 100;
        Range = 7;
        Speed = 15;
        Damage = 6;
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
