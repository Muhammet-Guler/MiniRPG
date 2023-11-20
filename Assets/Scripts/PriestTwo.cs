using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestTwo : ICharacter,IPunObservable
{
    public int SkillOneCoolDown, SkillTwoCoolDown, SkillThreeCoolDown, SkillFourCoolDown, SkillFiveCoolDown = 0;
    public Sprite sprite;
    public GameObject Priest2;

    public UnityEngine.UI.Text nickName;

    //public Skill skill;

    public void Update()
    {
        
    }
    public void Start()
    {
        CharacterAnimation = Priest2.GetComponent<Animator>();
        nickName.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public PriestTwo()
    {
        characterType = "Priest2";
        characterSprite = sprite;
        Health = 100;
        Range = 7;
        Speed = 10;
        Damage = 6;
        AttackPower = 10;
        Defence = 10;
        Description = "";
        instantieName = "Priest2(Clone)";
        this.skillList = null;
    }
    
    public void skillOne()
    {
        //skill.Skill_Attack9();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
    public void skillTwo()
    {
        //skill.Skill_Attack10();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
    public void skillThree()
    {
        //skill.Skill_Attack11();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
}
