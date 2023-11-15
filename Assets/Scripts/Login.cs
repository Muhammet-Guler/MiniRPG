using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{

    public GameObject UsernamePage;
    public UnityEngine.UI.Text MyUsername;
    void Start()
    {
        if (PlayerPrefs.GetString("Username") == "" || PlayerPrefs.GetString("Username") == null)
        {
            UsernamePage.SetActive(true);
        }
        else
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("Username");
            MyUsername.text = PlayerPrefs.GetString("Username");
            UsernamePage.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
