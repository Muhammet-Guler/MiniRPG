using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PriestTwo : ICharacter,IPunObservable
{
    public int SkillOneCoolDown, SkillTwoCoolDown, SkillThreeCoolDown, SkillFourCoolDown, SkillFiveCoolDown = 0;
    public Sprite sprite;
    public GameObject Priest2;
    public bool isCharacterAnimationPlaying;
    public UnityEngine.UI.Text nickName;

    private Animator animator;
    public AnimationSync animationSync;

    public Skills skill;

    public void Update()
    {
        CharacterAnimation = Priest2.GetComponent<Animator>();
        nickName.transform.rotation = new Quaternion(0, 0, 0, 0);
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
    public void PriestTwoClass()
    {
        characterName = "Priest2";
        characterSprite = sprite;
        Health = 100;
        Range = 7;
        Speed = 10;
        Damage = 6;
        AttackPower = 10;
        Defence = 10;
        Description = "";
        instantieName = "Priest(Clone)";
        CharacterAnimation = Priest2.GetComponent<Animator>();
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
            // Senkronize edilen verileri oku ve animasyonlar� ayarla
            animationSync.isPlaying = (bool)stream.ReceiveNext();
            animationSync.currentAnimation = (string)stream.ReceiveNext();

            animator.SetBool("isPlaying", animationSync.isPlaying);
            animator.Play(animationSync.currentAnimation);
        }
    }
    public void skillOne()
    {
        skill.Skill_Attack9();
        this.SkillOneCoolDown = skill.coolDown;
        CharacterAnimation.Play(skill.Name);
        isCharacterAnimationPlaying = true;
        Debug.Log(skill.Name);
    }
    public void skillTwo()
    {
        skill.Skill_Attack10();
        this.SkillOneCoolDown = skill.coolDown;
        CharacterAnimation.Play(skill.Name);
        isCharacterAnimationPlaying = true;
        Debug.Log(skill.Name);
    }
    public void skillThree()
    {
        skill.Skill_Attack11();
        this.SkillOneCoolDown = skill.coolDown;
        CharacterAnimation.Play(skill.Name);
        isCharacterAnimationPlaying = true;
        Debug.Log(skill.Name);
    }
}
