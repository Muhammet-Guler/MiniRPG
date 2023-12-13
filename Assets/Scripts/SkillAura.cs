using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAura : ISkill
{
    // Start is called before the first frame update
    void Start()
    {

        this.skillName = "Attack1 4";
        this.characterType = "Priest";
        this.description = " fire rainy";
        this.skillSprite = "Sprites/Priest/Holy_5";
        this.coolDown = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
