using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.PunBasics;

public class GameManager : MonoBehaviourPunCallbacks
{
    public float locationX;
    public float locationY;
    public FixedJoystick joystick;
    private GameObject mage;
    public Vector3 konum;
    public float donmeHizi = 10.0f;
    [SerializeField]
    private UnityEngine.UI.Button btn1, btn2, btn3;
    public float countdownDuration = 1f;
    PhotonView view;
    public Mage SelectedCharacter;
    void Start()
    {
        view=GetComponent<PhotonView>();
        SelectedCharacter = new Mage();
        SelectedCharacter.skillOne();
    }

    void Update()
    {
            SelectedCharacter = GameObject.Find("Mage(Clone)").GetComponent<Mage>();
            mage = GameObject.Find("Mage(Clone)");
            //mage.transform = GameObject.Find("Mage(Clone)").transform;
            locationX = joystick.Horizontal;
            locationY = joystick.Vertical;
            konum = mage.transform.position;
            mage.transform.position = new Vector3(mage.transform.position.x + locationX * ((float)0.005), mage.transform.position.y, mage.transform.position.z + locationY * ((float)0.005));
            if (joystick.Horizontal != 0 && joystick.Vertical != 0)
            {
                WalkAnimation();
                Vector3 yeniYon = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
                mage.transform.rotation = Quaternion.LookRotation(GetNewVelocity());
             }
             if (joystick.Horizontal == 0 && joystick.Vertical == 0 && SelectedCharacter.isCharacterAnimationPlaying == false)
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
        if (mage != null)
        {
            Animator CharacterAnimation = mage.GetComponent<Animator>();
            if (CharacterAnimation != null)
            {
                CharacterAnimation.Play("Walk");
                CharacterAnimation.Play("WalkForward");
            }
        }
    }
    public void IdleAnimation()
    {
        if (mage != null)
        {
            Animator CharacterAnimation = mage.GetComponent<Animator>();
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
            SelectedCharacter.isCharacterAnimationPlaying = false;
        }
    }
    public void attackOne()
    {
        SelectedCharacter.skillOne();
        StartCoroutine(StartCountdown());
    }
    public void attackTwo()
    {
        SelectedCharacter.skillTwo();
        StartCoroutine(StartCountdown());
    }
    public void attackThree()
    {
        SelectedCharacter.skillThree();
        StartCoroutine(StartCountdown());
    }
}
