using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Walk;
    public Animator Idle;
    public PlayerMovementController PlayerMovementController;
    void Start()
    {
        Walk = GetComponent<Animator>();
        Idle = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovementController.Durdur==true)
        {
            Idle.Play("Idle");
        }
        if (PlayerMovementController.Durdur == false)
        {
            Walk.Play("WalkForward");
        }
    }
}
