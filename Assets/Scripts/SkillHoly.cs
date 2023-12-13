using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHoly : ISkill
{
    // Start is called before the first frame update
    void Start()
    {
        this.skillName = "Attack1 6";
        this.characterType = "Priest";
        this.description = " fire rainy";
        this.skillSprite = "Sprites/Priest/Holy_7";
        this.coolDown = 13;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
