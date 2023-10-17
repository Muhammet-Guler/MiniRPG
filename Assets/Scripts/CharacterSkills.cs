using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterSkills : MonoBehaviourPunCallbacks
{
    public Animator Walk;
    public Animator Idle;
    //public Animator Attack;
    //public PlayerMovementController PlayerMovementController;
    private int SelectedCharacter;
    //public UnityEngine.UI.Button btn4, btn2, btn3;
   // public GameManager gameManager;
    private GameObject mage;
    private GameManager gameManager;
    private Animator CharacterAnimation;
    public bool isCharacterAnimationPlaying;
    PhotonView view;
    void Start()
    {
        //gameManager.attackOne();
        Walk = GetComponent<Animator>();
        Idle = GetComponent<Animator>();
        SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        gameManager = FindObjectOfType<GameManager>();
        isCharacterAnimationPlaying = false;
        view = GetComponent < PhotonView >();
        //if (btn1 != null)
        //{
        //    btn1.onClick.AddListener(ButtonClickAction);
        //}
        //if (btn2 != null)
        //{
        //    btn2.onClick.AddListener(ButtonClickAction);
        //}
        //if (btn3 != null)
        //{
        //    btn3.onClick.AddListener(ButtonClickAction);
        //}
        //Walk=gameObject.AddComponent<Animator>();
    }
    //void ButtonClickAction()
    //{
    //    Debug.Log("Button clicked!");
    //    if (Walk!=null)
    //    {
    //        Walk.Play("Attack1 2");
            
    //    }
    //    if (Walk==null)
    //    {
    //        Debug.Log("calismadi");
    //    }
    //}
    void Update()
    {
        if (view.IsMine)
        {
            mage = GameObject.Find("Mage(Clone)");
            if (gameManager.joystick.Horizontal == 0 && gameManager.joystick.Vertical == 0 && isCharacterAnimationPlaying == false)
            {
                Idle.Play("Idle");
            }

            if (gameManager.joystick.Horizontal != 0 && gameManager.joystick.Vertical != 0)
            {
                Walk.Play("WalkForward");
                Walk.Play("Walk");
                isCharacterAnimationPlaying = false;
            }
            CharacterAnimation = mage.GetComponent<Animator>();
        }
        
    }
    public void MageSkillsOne()
    {
        if (view.IsMine)
        {
            CharacterAnimation.Play("Attack1 0");
            isCharacterAnimationPlaying = true;
        }
    }
    public void MageSkillsTwo()
    {
        if (view.IsMine)
        {
            CharacterAnimation.Play("Attack1 4");
            isCharacterAnimationPlaying = true;
        }
    }
    public void MageSkillsThree()
    {
        if (view.IsMine)
        {
            CharacterAnimation.Play("SpinAttack_TwoWeapons");
            isCharacterAnimationPlaying = true;
        }
    }
    public void PriestSkills()
    {
        //if (SelectedCharacter == 1)
        //{
        //    btn1.onClick.AddListener(() =>
        //    {

        //        Walk.Play("Attack1 5");
        //    });
        //    btn2.onClick.AddListener(() =>
        //    {

        //        Walk.Play("Attack1 1");
        //    });
        //    btn3.onClick.AddListener(() =>
        //    {

        //        Walk.Play("Punch");
        //    });
        //    isAnimationPlaying = false;
        //    StartCoroutine(StartCountdown());
        //}

    }
    public void WarriorSkilss()
    {
        //if (SelectedCharacter == 2)
        //{
        //    btn1.onClick.AddListener(() =>
        //    {

        //        Walk.Play("Attack1 2");
        //    });
        //    btn2.onClick.AddListener(() =>
        //    {

        //        Walk.Play("Attack1 1");
        //    });
        //    btn3.onClick.AddListener(() =>
        //    {

        //        Walk.Play("Attack1 6");
        //    });
        //    isAnimationPlaying = false;
        //    StartCoroutine(StartCountdown());
        //}

    }
    public void PriestTwoSkilss()
    {
        //if (SelectedCharacter == 0)
        //{
        //    btn1.onClick.AddListener(() =>
        //    {

        //        Walk.Play("Punch 0");
        //    });
        //    btn2.onClick.AddListener(() =>
        //    {

        //        Walk.Play("Punch 1");
        //    });
        //    btn3.onClick.AddListener(() =>
        //    {

        //        Walk.Play("Attack1 3");
        //    });
        //}
    }
}
