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
        characterType = "Warrior";
        characterSprite = sprite;
        Health = 100;
        Range = 13;
        Speed = 3;
        Damage = 9;
        AttackPower = 10;
        Defence = 10;
        Description = "";
        instantieName = "Warrior(Clone)";
    }
}
