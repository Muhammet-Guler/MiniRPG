using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSkills : ISkill
{
    public List<string> allSkills = new List<string>{ "nova", "sword"};
    public void skillNova()
    {
        skillName = "nova";
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
