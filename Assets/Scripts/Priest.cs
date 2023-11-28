using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : ICharacter,IPunObservable
{
    public int SkillOneCoolDown, SkillTwoCoolDown, SkillThreeCoolDown, SkillFourCoolDown, SkillFiveCoolDown = 0;
    public Sprite sprite;
    public GameObject priest;
    public UnityEngine.UI.Text nickName;
    //public Skill skill;
    public void Update()
    {
    }
    public void Start()
    {

        CharacterAnimation = priest.GetComponent<Animator>();
        nickName.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public  Priest()
    {
        characterType = "Priest";
        characterSprite = sprite;
        Health = 100;
        Range = 7;
        Speed = 15;
        Damage = 6;
        AttackPower = 10;
        Defence = 10;
        Description = "";
        instantieName = "Priest(Clone)";
    }

    public void skillOne()
    {
        //skill.Skill_Attack3();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
    public void skillTwo()
    {
        //skill.Skill_Attack4();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
    public void skillThree()
    {
        //skill.Skill_Attack5();
        //this.SkillOneCoolDown = skill.coolDown;
        //CharacterAnimation.Play(skill.Name);
        //isCharacterAnimationPlaying = true;
        //Debug.Log(skill.Name);
    }
}
