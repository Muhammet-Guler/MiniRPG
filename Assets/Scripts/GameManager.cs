using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.PunBasics;
using Unity.VisualScripting;
using System.IO;
using System.Runtime.Serialization;

public class GameManager : MonoBehaviourPun
{
    public float locationX;
    public float locationY;
    public FixedJoystick joystick;
    private GameObject SelectedCharacter;
    public Vector3 konum;
    public float donmeHizi = 10.0f;
    [SerializeField]
    private UnityEngine.UI.Button btn1, btn2, btn3;
    public float countdownDuration = 1f;
    PhotonView view;
    public Mage Mage;
    public Priest Priest;
    public PriestTwo PriestTwo;
    public Warrior Warrior;
    public GameObject cube;
    private Color syncedColor = Color.red;
    private int selectedCharacterValue;
    private Skills skill;
    void Start()
    {
        view = GetComponent<PhotonView>();
        Mage = new Mage();
        Priest = new Priest();
        PriestTwo = new PriestTwo();
        Warrior = new Warrior();
        //Mage.skillOne();
        //cube.GetComponent<Renderer>().material.color = syncedColor;
    }



    void Update()
    {
        selectedCharacterValue = PlayerPrefs.GetInt("SelectedCharacter");
        if (selectedCharacterValue == 0)
        {
            PriestTwo = GameObject.Find("Pritest2(Clone)").GetComponent<PriestTwo>();
            SelectedCharacter = GameObject.Find("Pritest2(Clone)");
        }
        if (selectedCharacterValue == 1)
        {
            Priest = GameObject.Find("Priest(Clone)").GetComponent<Priest>();
            SelectedCharacter = GameObject.Find("Priest(Clone)");
        }
        if (selectedCharacterValue == 2)
        {
            Warrior = GameObject.Find("Warrior(Clone)").GetComponent<Warrior>();
            SelectedCharacter = GameObject.Find("Warrior(Clone)");
        }
        if (selectedCharacterValue == 3)
        {
            Mage = GameObject.Find("Mage(Clone)").GetComponent<Mage>();
            SelectedCharacter = GameObject.Find("Mage(Clone)");
        }
        locationX = joystick.Horizontal;
        locationY = joystick.Vertical;
        konum = SelectedCharacter.transform.position;
        SelectedCharacter.transform.position = new Vector3(SelectedCharacter.transform.position.x + locationX * ((float)2) * Time.deltaTime, SelectedCharacter.transform.position.y * Time.deltaTime, SelectedCharacter.transform.position.z + locationY * ((float)2) * Time.deltaTime);
        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            WalkAnimation();
            Vector3 yeniYon = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            SelectedCharacter.transform.rotation = Quaternion.LookRotation(GetNewVelocity());
        }
        if (joystick.Horizontal == 0 && joystick.Vertical == 0 && Mage.isCharacterAnimationPlaying == false && Priest.isCharacterAnimationPlaying == false && PriestTwo.isCharacterAnimationPlaying == false && Warrior.isCharacterAnimationPlaying == false)
        {
            IdleAnimation();
        }

    }
    //MageLocationX=skills.mage.transform.position.x;
    //MageLocationY= skills.mage.transform.position.y;
    //skills.mage.transform.position=new Vector3(skills.mage.transform.position.x+locationX, skills.mage.transform.position.y+locationY, skills.mage.transform.position.z);


    private Vector3 GetNewVelocity()
    {
        return new Vector3(joystick.Horizontal, 0, joystick.Vertical) * donmeHizi * Time.fixedDeltaTime;
    }

    public void WalkAnimation()
    {
        if (SelectedCharacter != null)
        {
            Animator CharacterAnimation = SelectedCharacter.GetComponent<Animator>();
            if (CharacterAnimation != null)
            {
                CharacterAnimation.Play("Walk");
                CharacterAnimation.Play("WalkForward");
            }
        }
    }
    public void IdleAnimation()
    {
        if (SelectedCharacter != null)
        {
            Animator CharacterAnimation = SelectedCharacter.GetComponent<Animator>();
            if (CharacterAnimation != null)
            {
                CharacterAnimation.Play("Idle");
            }
        }
    }
    private IEnumerator StartCountdown()
    {
        float currentTime = countdownDuration;

        while (currentTime > 0)
        {
            currentTime -= 1f;
            btn1.interactable = false;
            btn2.interactable = false;
            btn3.interactable = false;
            yield return new WaitForSeconds(1f);
            btn1.interactable = true;
            btn2.interactable = true;
            btn3.interactable = true;
            Mage.isCharacterAnimationPlaying = false;
            Priest.isCharacterAnimationPlaying = false;
            PriestTwo.isCharacterAnimationPlaying = false;
            Warrior.isCharacterAnimationPlaying = false;
        }
    }
    public void attackOne()
    {
        //if (selectedCharacterValue == 0)
        //{

        //    PriestTwo.skillOne();
        //    StartCoroutine(StartCountdown());
        //}
        //else if (selectedCharacterValue == 1)
        //{
        //    Priest.skillOne();
        //    StartCoroutine(StartCountdown());
        //}
        //else if (selectedCharacterValue == 2)
        //{
        //    Warrior.skillOne();
        //    StartCoroutine(StartCountdown());
        //}
        //else if (selectedCharacterValue == 3)
        //{
        //    Mage.skillOne();
        //    StartCoroutine(StartCountdown());
        //}
        Mage.skillOne();
        StartCoroutine(StartCountdown());

    }
    public void attackTwo()
    {
        selectedCharacterValue = PlayerPrefs.GetInt("SelectedCharacter");
        // if (selectedCharacterValue == 0)
        //{

        //    PriestTwo.skillTwo();
        //    StartCoroutine(StartCountdown());
        //}
        //else if (selectedCharacterValue == 1)
        //{
        //    Priest.skillTwo();
        //    StartCoroutine(StartCountdown());
        //}
        //else if (selectedCharacterValue == 2)
        //{
        //    Warrior.skillTwo();
        //    StartCoroutine(StartCountdown());
        //}
        //else if (selectedCharacterValue == 3)
        //{
        //    Mage.skillTwo();
        //    StartCoroutine(StartCountdown());
        Mage.skillTwo();
        StartCoroutine(StartCountdown());
        //}
    }
        public void attackThree()
        {
            selectedCharacterValue = PlayerPrefs.GetInt("SelectedCharacter");
        // if (selectedCharacterValue == 0)
        //{

        //    PriestTwo.skillThree();
        //    StartCoroutine(StartCountdown());
        //}
        //else if (selectedCharacterValue == 1)
        //{
        //    Priest.skillThree();
        //    StartCoroutine(StartCountdown());
        //}
        //else if (selectedCharacterValue == 2)
        //{
        //    Warrior.skillThree();
        //    StartCoroutine(StartCountdown());
        //}
        //else if (selectedCharacterValue == 3)
        //{
        //    Mage.skillThree();
        //    StartCoroutine(StartCountdown());
        //}
        Mage.skillThree();
        StartCoroutine(StartCountdown());
    }

    }

