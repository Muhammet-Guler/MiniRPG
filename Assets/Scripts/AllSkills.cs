using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSkills : ISkill
{
    public List<string> allSkills = new List<string>{ "nova", "sword"};
    public Sprite[] mageSkillSprites;
    public Sprite[] priestSkillSprites;
    public Sprite[] warriorSkillSprites;
    public Sprite[] priestTwoSkillSprites;
    public string[] mageSkillInformation = { "MageSkill", "MageSkill", "MageSkill", "MageSkill", "MageSkill", "MageSkill", "MageSkill", "MageSkill", "MageSkill", "MageSkill" };
    public string[] priestSkillInformation = { "PriestSkill", "PriestSkill", "PriestSkill", "PriestSkill", "PriestSkill", "PriestSkill", "PriestSkill", "PriestSkill", "PriestSkill", "PriestSkill" };
    public string[] warriorSkillInformation = { "WarriorSkill", "WarriorSkill", "WarriorSkill", "WarriorSkill", "WarriorSkill", "WarriorSkill", "WarriorSkill", "WarriorSkill", "WarriorSkill", "WarriorSkill" };
    public string[] priestTwoSkillInformation = { "PriestTwoSkill", "PriestTwoSkill", "PriestTwoSkill", "PriestTwoSkill", "PriestTwoSkill", "PriestTwoSkill", "PriestTwoSkill", "PriestTwoSkill", "PriestTwoSkill", "PriestTwoSkill" };
    public UnityEngine.UI.Text skillInfo;
    public void skillNova()
    {
        skillName = "Attack1 1";
        characterType = "Mage";
        description = " fire rainy";
    }
    public void skillSword()
    {
        skillName = "sword";
        characterType = "Warrior";
        description = "%300 demege";    
    }
    public void Start()
    {

    }
}
