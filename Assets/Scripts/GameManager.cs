using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private CharacterSkills skilss;
    public float locationX;
    public float locationY;
    public FixedJoystick joystick;
    private GameObject mage;
    public Vector3 konum;
    public float donmeHizi = 10.0f;
    void Start()
    {
        
    }

    void Update()
    {
        mage = GameObject.Find("Mage(Clone)");
        //mage.transform = GameObject.Find("Mage(Clone)").transform;
        locationX = joystick.Horizontal;
        locationY = joystick.Vertical;
        konum = mage.transform.position;
        Debug.Log("Oyuncu karakterinin konumu: " + konum);
        mage.transform.position = new Vector3(mage.transform.position.x+locationX*((float)0.005),mage.transform.position.y, mage.transform.position.z + locationY * ((float)0.005));
        if (joystick.Horizontal!=0&& joystick.Vertical!=0)
        {
            WalkAnimation();
            Vector3 yeniYon =new Vector3(joystick.Horizontal,0, joystick.Vertical);
            mage.transform.rotation = Quaternion.LookRotation(GetNewVelocity());
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
            Animator karakterAnimasyonu = mage.GetComponent<Animator>();
            if (karakterAnimasyonu != null)
            {
                karakterAnimasyonu.Play("Walk");
            }
            else
            {
                Debug.LogError("Karakterin Animator bileþeni bulunamadý.");
            }
        }
        else
        {
            Debug.LogError("Karakter bulunamadý.");
        }
    }
    public void attackOne()
    {
        skilss.MageSkillsOne();
    }
}
