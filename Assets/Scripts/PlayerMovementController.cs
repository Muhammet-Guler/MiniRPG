using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FixedJoystick))]
public class PlayerMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody playerRigiBody;
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private float moveSpeed=100;
    [SerializeField] private Transform playerChildTransform;
    [SerializeField] private AnimationController animationController;
    public Animator Walk;
    public bool Stop;


    public float _horizontal;
    public float _vertical;
    void Start()
    {
        Walk = GetComponent<Animator>();
        fixedJoystick = GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fixedJoystick!=null)
        {
            GetMovementInputs();
        }
    }
    private void FixedUpdate()
    {
        SetMovement();
        SetRoatation();
    }
    private void SetMovement()
    {
        playerRigiBody.velocity=GetNewVelocity();

    }

    private void SetRoatation()
    {
        if (_horizontal!=0||_vertical!=0)
        {
            playerChildTransform.rotation=Quaternion.LookRotation(GetNewVelocity());
            animationController.SetBoolean(animationType: "Walk", value: true);
            Stop = false;
            
        }
        else
        {
            animationController.SetBoolean(animationType: "Walk", value: false);
            Stop = true;
        }
    }
    private Vector3 GetNewVelocity()
    {
        return new Vector3(_horizontal,playerRigiBody.velocity.y,_vertical)*moveSpeed*Time.fixedDeltaTime;
    }
    private void GetMovementInputs()
    {
        _horizontal = fixedJoystick.Horizontal;
        _vertical = fixedJoystick.Vertical;
        //Debug.Log(_horizontal);
    }
}
