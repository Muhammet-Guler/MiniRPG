using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : ICharacter,IPunObservable
{
    public int SkillOneCoolDown, SkillTwoCoolDown, SkillThreeCoolDown, SkillFourCoolDown, SkillFiveCoolDown = 0;
    public Sprite sprite;
    public GameObject priest;
    public bool isCharacterAnimationPlaying;
    public UnityEngine.UI.Text nickName;

    private Animator animator;
    public AnimationSync animationSync;
    //public Skill skill;
    public void Update()
    {
        CharacterAnimation = priest.GetComponent<Animator>();
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
    public void PriestClass()
    {
        characterName = "Priest";
        characterSprite = sprite;
        Health = 100;
        Range = 7;
        Speed = 15;
        Damage = 6;
        AttackPower = 10;
        Defence = 10;
        Description = "";
        instantieName = "Priest(Clone)";
        CharacterAnimation = priest.GetComponent<Animator>();
        this.skillList = null;
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
