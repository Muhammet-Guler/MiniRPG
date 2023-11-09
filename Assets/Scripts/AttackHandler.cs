using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public Animator CharacterAnimation;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void useSkill(ISkill skill,TargetHandler target)
    {
        //skill.run();
        CharacterAnimation = GameObject.Find(skill.skillName + "(Clone)").GetComponent<Animator>();
    }
}
