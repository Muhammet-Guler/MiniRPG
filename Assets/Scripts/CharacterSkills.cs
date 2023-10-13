using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterSkills : MonoBehaviour
{
    public Animator Walk;
    public Animator Idle;
    public Animator Attack;
    public PlayerMovementController PlayerMovementController;
    private float currentTime;
    private bool isAnimationPlaying = true;
    public float countdownDuration = 1f;
    private int SelectedCharacter;
    //public UnityEngine.UI.Button btn4, btn2, btn3;
    [SerializeField]
    private UnityEngine.UI.Button btn1, btn2, btn3;
    void Start()
    {
        Walk = GetComponent<Animator>();
        Idle = GetComponent<Animator>();
        SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        if (btn1 != null)
        {
            btn1.onClick.AddListener(ButtonClickAction);
        }
        if (btn2 != null)
        {
            btn2.onClick.AddListener(ButtonClickAction);
        }
        if (btn3 != null)
        {
            btn3.onClick.AddListener(ButtonClickAction);
        }
    }
    void ButtonClickAction()
    {
        Debug.Log("Button clicked!");
        if (Walk!=null)
        {
            Walk.Play("Attack1 2");
            
        }
        if (Walk==null)
        {
            Debug.Log("calismadi");
        }
    }
    void Update()
    {
        if (isAnimationPlaying == true)
        {
            if (PlayerMovementController.Stop == true)
            {
                Idle.Play("Idle");
            }
        }
        if (PlayerMovementController.Stop == false)
        {
            Walk.Play("WalkForward");
            Walk.Play("Walk");
        }
    }
    public void MageSkills()
    {
        if (SelectedCharacter == 3)
        {
            btn1.onClick.AddListener(() =>
            {

                Walk.Play("Attack1 0");
            });
            btn2.onClick.AddListener(() =>
            {

                Walk.Play("Attack1 4");
            });
            btn3.onClick.AddListener(() =>
            {

                Walk.Play("SpinAttack_TwoWeapons");
            });
            isAnimationPlaying = false;
            StartCoroutine(StartCountdown());
        }
    }
    public void PriestSkills()
    {
        if (SelectedCharacter == 1)
        {
            btn1.onClick.AddListener(() =>
            {

                Walk.Play("Attack1 5");
            });
            btn2.onClick.AddListener(() =>
            {

                Walk.Play("Attack1 1");
            });
            btn3.onClick.AddListener(() =>
            {

                Walk.Play("Punch");
            });
            isAnimationPlaying = false;
            StartCoroutine(StartCountdown());
        }

    }
    public void WarriorSkilss()
    {
        if (SelectedCharacter == 2)
        {
            btn1.onClick.AddListener(() =>
            {

                Walk.Play("Attack1 2");
            });
            btn2.onClick.AddListener(() =>
            {

                Walk.Play("Attack1 1");
            });
            btn3.onClick.AddListener(() =>
            {

                Walk.Play("Attack1 6");
            });
            isAnimationPlaying = false;
            StartCoroutine(StartCountdown());
        }

    }
    public void PriestTwoSkilss()
    {
        if (SelectedCharacter == 0)
        {
            btn1.onClick.AddListener(() =>
            {

                Walk.Play("Punch 0");
            });
            btn2.onClick.AddListener(() =>
            {

                Walk.Play("Punch 1");
            });
            btn3.onClick.AddListener(() =>
            {

                Walk.Play("Attack1 3");
            });
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
        }
        isAnimationPlaying = true;
    }
}
