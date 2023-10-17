using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    private CharacterSkills skilss;
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
    void Start()
    {
        view=GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            skilss = GameObject.Find("Mage(Clone)").GetComponent<CharacterSkills>();
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
            skilss.isCharacterAnimationPlaying = false;
        }
    }
    public void attackOne()
    {
        skilss.MageSkillsOne();
        StartCoroutine(StartCountdown());
    }
    public void attackTwo()
    {
        skilss.MageSkillsTwo();
        StartCoroutine(StartCountdown());
    }
    public void attackThree()
    {
        skilss.MageSkillsThree();
        StartCoroutine(StartCountdown());
    }
}
