using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character1 : MonoBehaviour
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

    void Start()
    {
        Walk = GetComponent<Animator>();
        Idle = GetComponent<Animator>();
        SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
    }

    // Update is called once per frame
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
    public void AttackSkill()
    {
        if (SelectedCharacter==0)
        {
            Walk.Play("Attack1 0");
        }
        if (SelectedCharacter == 1)
        {
            Walk.Play("Attack1 1");
        }
        if (SelectedCharacter == 2)
        {
            Walk.Play("Attack1 2");
        }
        if (SelectedCharacter == 3)
        {
            Walk.Play("Attack1 3");
        }
        isAnimationPlaying = false;
       StartCoroutine(StartCountdown());
    }
    public void AttackSkill2()
    {
        if (SelectedCharacter == 0)
        {
            Walk.Play("Attack1 4");
        }
        if (SelectedCharacter == 1)
        {
            Walk.Play("Attack1 5");
        }
        if (SelectedCharacter == 2)
        {
            Walk.Play("Attack1 6");
        }
        if (SelectedCharacter == 3)
        {
            Walk.Play("SpinAttack_TwoWeapons");
        }
        isAnimationPlaying = false;
        StartCoroutine(StartCountdown());
    }
    public void Ulti()
    {
        if (SelectedCharacter == 0)
        {
            Walk.Play("SpinAttack_TwoWeapons");
        }
        if (SelectedCharacter == 1)
        {
            Walk.Play("Punch");
        }
        if (SelectedCharacter == 2)
        {
            Walk.Play("Punch 0");
        }
        if (SelectedCharacter == 3)
        {
            Walk.Play("Punch 1");
        }
        isAnimationPlaying = false;
        StartCoroutine(StartCountdown());
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
