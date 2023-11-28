using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllSkills : ISkill
{
    public static List<ISkill> Skillist = new List<ISkill>();
    public UnityEngine.UI.Text skillInfo;
    //public System.Action[] mageFunctions;


    public void Awake()
    {
        // mageFunctions = new System.Action[]
        //{
        //     skillNova,
        //     skillSword
        //    // Ek fonksiyonlar ekleyebilirsiniz
        //};

    }
    public void Start()
    {
        skillNova();
        skillSword();
        skill1();
        skill2();
        skill3();
    }


    //Nova skill object creater
    public void  skillNova()
    {
        ISkill skill = new ISkill();
        skill.skillName = "Attack1 1";
        skill.characterType = "Mage";
        skill.description = " fire rainy";
        skill.skillSprite = "Sprites/Dark_6";
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);


    }
    public void skill1()
    {
        ISkill skill = new ISkill();
        skill.skillName = "Attack1 1";
        skill.characterType = "Mage";
        skill.description = " fire rainy";
        skill.skillSprite = "Sprites/Dark_6";
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);


    }
    public void skill2()
    {
        ISkill skill = new ISkill();
        skill.skillName = "Attack1 1";
        skill.characterType = "Mage";
        skill.description = " fire rainy";
        skill.skillSprite = "Sprites/Dark_6";
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);


    }
    public void skill3()
    {
        ISkill skill = new ISkill();
        skill.skillName = "Attack1 1";
        skill.characterType = "Mage";
        skill.description = " fire rainy";
        skill.skillSprite = "Sprites/Dark_6";
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);


    }
    public void skillSword()
    {
        ISkill skill = new ISkill();
        skill.skillName = "Attack1 2";
        skill.characterType = "Warrior";
        skill.description = "%300 demege";
        skill.skillSprite = "Sprites/Dark_7";
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);
    }

  
}
