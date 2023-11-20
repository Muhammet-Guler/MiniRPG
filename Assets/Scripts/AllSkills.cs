using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSkills : ISkill
{
    public List<ISkill> Skillist = new List<ISkill>();
    public UnityEngine.UI.Text skillInfo;

    public void Awake()
    {

        skillNova();
        skillSword();
    }



    //Nova skill object creater
    public void  skillNova()
    {
        ISkill skill = new ISkill();
        skill.skillName = "Attack1 1";
        skill.characterType = "Mage";
        skill.description = " fire rainy";
        skillSprite = Resources.Load<Sprite>("Sprites/Dark_6");
        Skillist.Add(skill);



    }
    public void skillSword()
    {
        ISkill skill = new ISkill();
        skill.skillName = "sword";
        skill.characterType = "Warrior";
        skill.description = "%300 demege";
        skillSprite = Resources.Load<Sprite>("Sprites/Dark_7");
        Skillist.Add(skill);
    }

  
}
