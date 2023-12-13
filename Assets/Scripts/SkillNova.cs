using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNova : ISkill
{
    // Start is called before the first frame update
    void Start()
    {

        this.skillName = "Attack1 1";
        this.characterType = "Mage";
        this.description = " fire rainy";
        this.skillSprite = "Sprites/Mage/Fire_5";
        this.coolDown = 14;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
