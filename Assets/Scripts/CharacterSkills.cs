using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterSkills : MonoBehaviourPunCallbacks
{
    public Animator Walk;
    public Animator Idle;
    //public Animator Attack;
    //public PlayerMovementController PlayerMovementController;
    private int SelectedCharacter;
    //public UnityEngine.UI.Button btn4, btn2, btn3;
   // public GameManager gameManager;
    private GameObject mage;
    private GameManager gameManager;
    private Animator CharacterAnimation;
    private Mage MageCharacterScript;
    private Warrior WarriorCharacterScript;
    private Priest PriestCharacterScript;
    private PriestTwo PriestTwoCharacterScript;
    void Start()
    {
        //gameManager.attackOne();
        //Walk = GetComponent<Animator>();
        //Idle = GetComponent<Animator>();
        //SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        //gameManager = FindObjectOfType<GameManager>();
        
    }
    
    void Update()
    {
            //mage = GameObject.Find("Mage(Clone)");
            //CharacterAnimation = mage.GetComponent<Animator>();
    }
    
    
}
