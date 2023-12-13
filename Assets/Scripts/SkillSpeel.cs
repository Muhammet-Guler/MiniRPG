using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpeel : ISkill
{
    // Start is called before the first frame update
    void Start()
    {
        this.skillName = "Attack1 2";
        this.characterType = "Mage";
        this.description = " fire rainy";
        this.skillSprite = "Sprites/Mage/Fire_7";
        this.coolDown = 16;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
