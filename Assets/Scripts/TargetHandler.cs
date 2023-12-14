using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHandler : MonoBehaviour
{
    public int TargetHp;
    public string TargetNickname;
    public Vector3 TargetLOcation;
    public Image HealthBar;
    public Animator characterAnimator;

    void Start()
    {

    }

    void Update()
    {

    }
    public void TakeDamage(float damageAmount,ICharacter icharacter)
    {
        HealthBar.fillAmount -= damageAmount;
        if (HealthBar.fillAmount <= 0)
        {
            characterAnimator.Play("IdleCombat");
        }
    }
}
