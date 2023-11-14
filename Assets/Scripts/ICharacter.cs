using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  abstract class ICharacter:MonoBehaviourPun
{ 
    public string characterName;
    public Sprite characterSprite;
    public int Health;
    public float Range;
    public float Speed;
    public int Damage;
    public int AttackPower;
    public int Defence;
    public string Description;
    public string instantieName;
    public List<ISkill> skillList;

    public bool isCharacterAnimationPlaying;

    public Animator CharacterAnimation;

    private Animator animator;
    public AnimationSync animationSync;

    public ICharacter()
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

