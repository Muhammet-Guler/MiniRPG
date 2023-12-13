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
    public UnityEngine.UI.Text nickName;



    public Mage()
    {
        this.characterType = "Mage";
        this.characterSprite = sprite;
        this.Health = 100;
        this.Range = 10;
        this.Speed = 5;
        this.Damage = 7;
        this.AttackPower = 10;
        this.Defence = 10;
        this.Description = "";
        this.instantieName = "Mage(Clone)";
    }

    public void Update()
    {
    }
    public void Start()
    {
        CharacterAnimation = mage.GetComponent<Animator>();
        nickName.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
