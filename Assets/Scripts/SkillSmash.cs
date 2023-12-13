using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillSmash : ISkill
{
    // Start is called before the first frame update
    void Start()
    {
        this.skillName = "Attack1 7";
        this.characterType = "Warrior";
        this.description = "%300 demege";
        this.skillSprite = "Sprites/Warrior/Nature_2";
        this.coolDown = 15;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
