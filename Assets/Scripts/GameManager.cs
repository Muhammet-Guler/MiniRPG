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
    private UnityEngine.UI.Button btn1, btn2, btn3,btn4,btn5,btn6;
    public float countdownDuration = 1f;
    PhotonView view;
    public CharacterManager CManager;
    public bool isCharacterAnimationPlaying=false;
    [SerializeField] private Image healthBarSprite;
    public ICharacter icharacter;
    public ISkill iskill;
    private bool isClickable = true;
    public Image skillImage1,skillImage2,skillImage3;
    public UnityEngine.UI.Text skillCountText1, skillCountText2, skillCountText3;
    public Button btn;
    public Transform[] players;
    public GameObject character;
    public int health;

    void Start()
    {
        //btn4.image.sprite= Resources.Load<Sprite>(CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 3].skillSprite);
        //btn5.image.sprite = Resources.Load<Sprite>(CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 2].skillSprite);
        //btn6.image.sprite = Resources.Load<Sprite>(CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 1].skillSprite);
        skillImage1.sprite= Resources.Load<Sprite>(CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 3].skillSprite);
       // skillImage1.rectTransform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        skillImage2.sprite = Resources.Load<Sprite>(CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 2].skillSprite);
        //skillImage2.rectTransform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        skillImage3.sprite = Resources.Load<Sprite>(CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 1].skillSprite);
        //skillImage3.rectTransform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        players = FindObjectsOfType<Transform>();
    }





void Update()
    {

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
        if (joystick.Horizontal == 0 && joystick.Vertical == 0 && isCharacterAnimationPlaying == false )
        {
            IdleAnimation();
        }
        PhotonView[] photonViews = GameObject.FindObjectsOfType<PhotonView>();
        List<PhotonView> photonViewListesi = new List<PhotonView>(photonViews);
        List<PhotonView> bulunanPhotonViews = photonViewListesi.FindAll(pv => pv.name.Contains("Clone"));

        if (bulunanPhotonViews.Count > 0)
        {
            Debug.Log("Aranan kelime içeren PhotonView'ler bulundu:");

            foreach (PhotonView bulunanPhotonView in bulunanPhotonViews)
            {
                Debug.Log("ID: " + bulunanPhotonView.ViewID + ", Ýsim: " + bulunanPhotonView.name);
                character = GameObject.Find(bulunanPhotonView.name);
                health = character.GetComponent<ICharacter>().Health;
                Debug.Log("health" + health);
            }
            for (int i = 0; i < bulunanPhotonViews.Count; i++)
            {

                //float distance = Vector3.Distance(GameObject.Find(PlayerPrefs.GetString("selectedCharacter") + "(Clone)").transform.position, players[i].position);
                float distance = Vector3.Distance(GameObject.Find(bulunanPhotonViews[i].name).transform.position, GameObject.Find(bulunanPhotonViews[i + 1].name).transform.position);
                if (distance < 5f)
                {
                    if (photonView.IsMine!)
                    {
                        character = GameObject.Find(bulunanPhotonViews[i].name);
                        Image buttonImage = btn.GetComponent<Image>();
                        buttonImage.sprite = character.GetComponent<ICharacter>().characterSprite;
                        Debug.Log(bulunanPhotonViews[i].name);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Aranan kelime içeren PhotonView bulunamadý.");
        }
    }
    void ListelePhotonNesneleri()
    {
       
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
            isCharacterAnimationPlaying = true;
            currentTime -= 1f;
            yield return new WaitForSeconds(1f);
            isCharacterAnimationPlaying = false;
        }
    }
    IEnumerator GeriSayim()
    {
        int value = CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 3].coolDown;
        while (value> 0f)
        {
            isClickable = false;
            Color imageColor = skillImage1.color;
            imageColor.a = 0.5f;
            skillImage1.color = imageColor;
            value--;
            yield return new WaitForSeconds(1f);
            skillCountText1.text = value.ToString();
            isClickable = true;
            Color imageColor2 = skillImage1.color;
            imageColor2.a = 1f;
            skillImage1.color = imageColor2;
            if (value==0)
            {
                skillCountText1.text = " ";
            }
        }
    }
    IEnumerator GeriSayim2()
    {
        int value = CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 2].coolDown;
        while (value > 0f)
        {
            isClickable = false;
            Color imageColor = skillImage2.color;
            imageColor.a = 0.5f;
            skillImage2.color = imageColor;
            value--;
            yield return new WaitForSeconds(1f);
            skillCountText2.text = value.ToString();
            isClickable = true;
            Color imageColor2 = skillImage2.color;
            imageColor2.a = 1f;
            skillImage2.color = imageColor2;
            if (value == 0)
            {
                skillCountText2.text = " ";
            }
        }
    }
    IEnumerator GeriSayim3()
    {
        int value = CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 1].coolDown;
        while ( value > 0f)
        {
            isClickable = false;
            Color imageColor = skillImage3.color;
            imageColor.a = 0.5f;
            skillImage3.color = imageColor;
            value--;
            yield return new WaitForSeconds(1f);
            skillCountText3.text = value.ToString();
            isClickable = true;
            Color imageColor2 = skillImage3.color;
            imageColor2.a = 1f;
            skillImage3.color = imageColor2;
            if (value == 0)
            {
                skillCountText3.text = " ";
            }
        }
    }
    public void attackOne()
    {
        if (isClickable)
        {
            Animator CharacterAnimation = SelectedCharacter.GetComponent<Animator>();
            if (CharacterAnimation != null)
                //CharacterAnimation.Play(CharacterManager.icharacter.skillList[0].skillName);
                CharacterAnimation.Play(CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 3].skillName);
            StartCoroutine(StartCountdown());
            healthBarSprite = SelectedCharacter.transform.Find("Canvas/Elite/Bars/Healthbar").GetComponent<Image>();
            healthBarSprite.fillAmount += 0.1f;
            StartCoroutine(GeriSayim());
        }

        ListelePhotonNesneleri();

    }
    public void attackTwo()
    {
        Animator CharacterAnimation = SelectedCharacter.GetComponent<Animator>();
        if (CharacterAnimation != null)
        //CharacterAnimation.Play(CharacterManager.icharacter.skillList[1].skillName);
        CharacterAnimation.Play(CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count-2].skillName);
        //StartCoroutine(StartCountdown());
        StartCoroutine(StartCountdown());
        healthBarSprite = SelectedCharacter.transform.Find("Canvas/Elite/Bars/Healthbar").GetComponent<Image>();
        healthBarSprite.fillAmount += 0.1f;
        StartCoroutine(GeriSayim2());
    }
    public void attackThree()
     {
        Animator CharacterAnimation = SelectedCharacter.GetComponent<Animator>();
        if (CharacterAnimation != null)
        //CharacterAnimation.Play(CharacterManager.icharacter.skillList[2].skillName);
        CharacterAnimation.Play(CharacterManager.selectedSkillList[CharacterManager.selectedSkillList.Count - 1].skillName);
        Debug.Log(CharacterManager.selectedSkillList.Count - 1);
        //StartCoroutine(StartCountdown());
        StartCoroutine(StartCountdown());
        healthBarSprite = SelectedCharacter.transform.Find("Canvas/Elite/Bars/Healthbar").GetComponent<Image>();
        healthBarSprite.fillAmount += 0.1f;
        StartCoroutine(GeriSayim3());
    }

    }

