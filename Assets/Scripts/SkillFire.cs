using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillFire : ISkill
{
    // Start is called before the first frame update
    void Start()
    {
        this.skillName = "Attack1 9";
        this.characterType = "Mage";
        this.description = " fire rainy";
        this.skillSprite = "Sprites/Mage/Fire_8";
        this.coolDown = 11;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
