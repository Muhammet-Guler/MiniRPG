using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : ICharacter,IPunObservable
{
    public int SkillOneCoolDown, SkillTwoCoolDown, SkillThreeCoolDown, SkillFourCoolDown, SkillFiveCoolDown = 0;
    public Sprite sprite;
    public GameObject warrior;
    public UnityEngine.UI.Text nickName;
    //public Skill skill;
    public void Update()
    {
    }
    public void Start()
    {

        CharacterAnimation = warrior.GetComponent<Animator>();
        nickName.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public  Warrior()
    {
        characterName = "Warrior";
        characterSprite = sprite;
        Health = 100;
        Range = 13;
        Speed = 3;
        Damage = 9;
        AttackPower = 10;
        Defence = 10;
        Description = "";
        instantieName = "Warrior(Clone)";
        this.skillList = null;
    }
    public void skillOne()
    {
        //skill.Skill_Attack6();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
    public void skillTwo()
    {
        //skill.Skill_Attack7();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
    public void skillThree()
    {
        //skill.Skill_Attack8();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
}
