using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllSkills:MonoBehaviour
{
    public static List<ISkill> Skillist = new List<ISkill>();
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
        skillSpeel();
        skillFire();
        skillSmash();
        skillSprint();
        skillAura();
        skillHoly();
        skillHeal();
    }
    
    //Nova skill object creater
    public void  skillNova()
    {
        ISkill skill = gameObject.AddComponent<SkillNova>();
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);


    }
    public void skillSpeel()
    {
        ISkill skill = gameObject.AddComponent<SkillSpeel>();
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);


    }
    public void skillFire()
    {
        ISkill skill = gameObject.AddComponent<SkillFire>();
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);


    }
    public void skillSmash()
    {
        ISkill skill = gameObject.AddComponent<SkillSmash>();
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);


    }
    public void skillSword()
    {
        ISkill skill = gameObject.AddComponent<SkillSword>();
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);
    }
    public void skillSprint()
    {
        ISkill skill = gameObject.AddComponent<SkillSprint>();
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);
    }
    public void skillAura()
    {
        ISkill skill = gameObject.AddComponent<SkillAura>();
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);
    }

    public void skillHoly()
    {
        ISkill skill = gameObject.AddComponent<SkillHoly>();
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);
    }

    public void skillHeal()
    {
        ISkill skill = gameObject.AddComponent<SkillHeal>();
        Skillist.Add(skill);
        //mageSpriteList.Add(skillSprite);
    }


}
