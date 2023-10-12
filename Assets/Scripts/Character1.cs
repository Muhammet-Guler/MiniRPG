using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Walk;
    public Animator Idle;
    public Animator Attack;
    public PlayerMovementController PlayerMovementController;
    private float currentTime;
    private bool isAnimationPlaying = true;
    public float countdownDuration = 1f;
    private int SelectedCharacter;
    public UnityEngine.UI.Button btn1,btn2,btn3;

    [PunRPC]
    void Start()
    {
        Walk = GetComponent<Animator>();
        Idle = GetComponent<Animator>();
        SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
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
    public void PriestSkills()
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
    public void WarriorSkilss()
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
    public void PriestTwoSkilss()
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
