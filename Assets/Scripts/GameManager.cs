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
using UnityEngine.TextCore.Text;

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
    public CharacterManager CManager;
    private string selectedCharacter;
    //private Skill skill;
    void Start()
    {
    }



    void Update()
    {
        //GameObject.Find(iCharacter.instantieName).GetComponent<ICharacter>();

        Debug.Log("GameManager calisti");
        Debug.Log("iCharacter:" + CharacterManager.icharacter.instantieName);
        view = GetComponent<PhotonView>();
        SelectedCharacter = GameObject.Find(CharacterManager.icharacter.instantieName.ToString());
        GameObject.Find(CharacterManager.icharacter.instantieName).GetComponent<ICharacter>();
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
        if (joystick.Horizontal == 0 && joystick.Vertical == 0 && CharacterManager.icharacter.isCharacterAnimationPlaying == false )
        {
            IdleAnimation();
        }

    }

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
            CharacterManager.icharacter.isCharacterAnimationPlaying = false;
        }
    }
    public void attackOne()
    {
        StartCoroutine(StartCountdown());

    }
    public void attackTwo()
    {
        StartCoroutine(StartCountdown());
    }
    public void attackThree()
     {
        StartCoroutine(StartCountdown());
    }

    }

