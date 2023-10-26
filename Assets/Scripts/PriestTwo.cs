using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestTwo : Character,IPunObservable
{
    public int SkillOneCoolDown, SkillTwoCoolDown, SkillThreeCoolDown, SkillFourCoolDown, SkillFiveCoolDown = 0;
    public Sprite sprite;
    public GameObject Priest2;
    public Animator CharacterAnimation;
    public bool isCharacterAnimationPlaying;
    public UnityEngine.UI.Text nickName;

    private Animator animator;
    public AnimationSync animationSync;
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
    }
    public override void skillOne()
    {
        this.SkillOneCoolDown = 5;
        CharacterAnimation.Play("Attack1 3");
        isCharacterAnimationPlaying = true;
    }
    public override void skillTwo()
    {
        this.SkillOneCoolDown = 5;
        CharacterAnimation.Play("Attack1 4");
        isCharacterAnimationPlaying = true;
    }
    public override void skillThree()
    {
        this.SkillOneCoolDown = 5;
        CharacterAnimation.Play("Attack1 5");
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
}
