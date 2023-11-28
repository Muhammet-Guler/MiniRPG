using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Mage : ICharacter, IPunObservable
{
    public int SkillOneCoolDown, SkillTwoCoolDown, SkillThreeCoolDown, SkillFourCoolDown, SkillFiveCoolDown=0;
    public Sprite sprite;
    public GameObject mage;
    public UnityEngine.UI.Text nickName;



    public Mage()
    {
        this.characterType = "Mage";
        this.characterSprite = sprite;
        this.Health = 100;
        this.Range = 10;
        this.Speed = 5;
        this.Damage = 7;
        this.AttackPower = 10;
        this.Defence = 10;
        this.Description = "";
        this.instantieName = "Mage(Clone)";
    }

    public void Update()
    {
        //CharacterAnimation = mage.GetComponent<Animator>();
    }
    public void Start()
    {
        CharacterAnimation = mage.GetComponent<Animator>();
        nickName.transform.rotation = new Quaternion(0, 0, 0, 0);
    }



    

    public void skillOne()
    {
        //skill.AttackSkill_Spike();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
    public void skillTwo()
    {
        //skill.Skill_Attack();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
    public void skillThree()
    {
        //skill.Skill_Attack2();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }

}
