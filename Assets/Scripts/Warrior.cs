using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : ICharacter,IPunObservable
{
    public int SkillOneCoolDown, SkillTwoCoolDown, SkillThreeCoolDown, SkillFourCoolDown, SkillFiveCoolDown = 0;
    public Sprite sprite;
    public GameObject warrior;
    public bool isCharacterAnimationPlaying;
    public UnityEngine.UI.Text nickName;

    private Animator animator;
    public AnimationSync animationSync;
    //public Skill skill;
    public void Update()
    {
        CharacterAnimation = warrior.GetComponent<Animator>();
        nickName.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    public void Start()
    {
        //if (photonView.IsMine)
        //{

        //    nickName.text = PhotonNetwork.NickName;
        //}
        //if (!photonView.IsMine)
        //{

        //    nickName.text = GetComponent<PhotonView>().Controller.NickName;
        //}
    }
    public void WarriorClass()
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
        CharacterAnimation = warrior.GetComponent<Animator>();
        this.skillList = null;
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
