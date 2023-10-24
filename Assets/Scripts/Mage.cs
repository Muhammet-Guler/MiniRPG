using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Mage : Character
{
    public int SkillOneCoolDown, SkillTwoCoolDown, SkillThreeCoolDown, SkillFourCoolDown, SkillFiveCoolDown=0;
    public Sprite sprite;
    public GameObject mage;
    public Animator CharacterAnimation;
    public bool isCharacterAnimationPlaying;
    public UnityEngine.UI.Text nickName;
    public void Update()
    {
        CharacterAnimation = mage.GetComponent<Animator>();
        nickName.transform.rotation = new Quaternion(0,0,0,0);
    }
    public void Start()
    {
        if (photonView.IsMine)
        {

            nickName.text = PhotonNetwork.NickName;
        }
        if (!photonView.IsMine)
        {

            nickName.text = GetComponent<PhotonView>().Controller.NickName;
        }
    }
    public void MageClass()
    {
        characterName = "Mage";
        characterSprite = sprite;
        Health = 100;
        Range = 10;
        Speed = 5;
        Damage = 7;
        AttackPower = 10;
        Defence = 10;
        isCharacterAnimationPlaying = false;
    }
    public  override void skillOne()
    {
        this.SkillOneCoolDown = 5;
        CharacterAnimation.Play("Attack1 0");
        isCharacterAnimationPlaying = true;
    }
    public override void skillTwo()
    {
        this.SkillOneCoolDown = 5;
        CharacterAnimation.Play("Attack1 1");
        isCharacterAnimationPlaying = true;
    }
    public override void skillThree()
    {
        this.SkillOneCoolDown = 5;
        CharacterAnimation.Play("Attack1 2");
        isCharacterAnimationPlaying = true;
    }
    public override void skillFour()
    {

    }
    public override void skillFive()
    {

    }
    public override void AttackDamage()
    {

    }
    public override void RecieveDamage()
    {

    }
}
