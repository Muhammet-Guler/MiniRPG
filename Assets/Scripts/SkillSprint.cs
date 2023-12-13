using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSprint : ISkill
{
    // Start is called before the first frame update
    void Start()
    {
        this.skillName = "Attack1 8";
        this.characterType = "Warrior";
        this.description = "%300 demege";
        this.skillSprite = "Sprites/Warrior/Nature_6";
        this.coolDown = 17;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
