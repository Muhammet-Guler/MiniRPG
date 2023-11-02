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
    public bool isCharacterAnimationPlaying;
    public UnityEngine.UI.Text nickName;

    private Animator animator;
    public AnimationSync animationSync;
    public Skills skill;

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
        Description = "";
        instantieName = "Mage(Clone)";
        //skil_1 = 1;
        //skil_id = 2;
        //skil_id = 3;
        //skil_id = 4;
        //skil_id = 5;
        CharacterAnimation=mage.GetComponent<Animator>();
    }
    public override void AttackDamage()
    {

    }
    public override void RecieveDamage()
    {

    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animationSync = new AnimationSync();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Senkronize edilecek verileri yaz
            stream.SendNext(animator.GetBool("isPlaying"));
            stream.SendNext(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        }
        else
        {
            // Senkronize edilen verileri oku ve animasyonlarý ayarla
            animationSync.isPlaying = (bool)stream.ReceiveNext();
            animationSync.currentAnimation = (string)stream.ReceiveNext();
            animator.SetBool("isPlaying", animationSync.isPlaying);
            animator.Play(animationSync.currentAnimation);
        }
    }

    public void skillOne()
    {
        skill.Skill_Spike();
        this.SkillOneCoolDown = skill.coolDown;
        CharacterAnimation.Play(skill.Name);
        isCharacterAnimationPlaying = true;
        Debug.Log(skill.Name);
    }
    public void skillTwo()
    {
        skill.Skill_Attack();
        this.SkillOneCoolDown = skill.coolDown;
        CharacterAnimation.Play(skill.Name);
        isCharacterAnimationPlaying = true;
        Debug.Log(skill.Name);
    }
    public void skillThree()
    {
        skill.Skill_Attack2();
        this.SkillOneCoolDown = skill.coolDown;
        CharacterAnimation.Play(skill.Name);
        isCharacterAnimationPlaying = true;
        Debug.Log(skill.Name);
    }

}
