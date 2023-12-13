using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSword : ISkill
{
    // Start is called before the first frame update
    void Start()
    {
        this.skillName = "Attack1 5";
        this.characterType = "Warrior";
        this.description = "%300 demege";
        this.skillSprite = "Sprites/Warrior/Nature_4";
        this.coolDown = 18;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
