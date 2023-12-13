using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHeal : ISkill
{
    // Start is called before the first frame update
    void Start()
    {
        this.skillName = "Attack1 3";
        this.characterType = "Priest";
        this.description = " fire rain";
        this.skillSprite = "Sprites/Priest/Holy_6";
        this.coolDown = 12;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
