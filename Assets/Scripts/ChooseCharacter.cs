using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Text ChooseText;
    public UnityEngine.UI.Button Karakter1, Karakter2, Karakter3, Karakter4;
    public string Karakter;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void karakterBir()
    {
        Karakter1.onClick.AddListener(() =>
         {
             Karakter1.interactable = false;
             Karakter2.interactable = false;
             Karakter3.interactable = false;
             Karakter4.interactable = false;
         });
        ChooseText.color = Color.green;
        PlayerPrefs.SetString("Karakter1",Karakter);
    }
    public void karakterIki()
    {
        Karakter2.onClick.AddListener(() =>
        {
            Karakter1.interactable = false;
            Karakter2.interactable = false;
            Karakter3.interactable = false;
            Karakter4.interactable = false;
        });
        ChooseText.color = Color.green;
        PlayerPrefs.SetString("Karakter2", Karakter);
    }
    public void karakterUc()
    {
        Karakter3.onClick.AddListener(() =>
        {
            Karakter1.interactable = false;
            Karakter2.interactable = false;
            Karakter3.interactable = false;
            Karakter4.interactable = false;
        });
        ChooseText.color = Color.green;
        PlayerPrefs.SetString("Karakter3", Karakter);
    }
    public void karakterDort()
    {
        Karakter4.onClick.AddListener(() =>
        {
            Karakter1.interactable = false;
            Karakter2.interactable = false;
            Karakter3.interactable = false;
            Karakter4.interactable = false;
        });
        ChooseText.color = Color.green;
        PlayerPrefs.SetString("Karakter4", Karakter);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
