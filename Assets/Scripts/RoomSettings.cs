using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSettings : MonoBehaviour
{
    public int maxPlayer;
    public UnityEngine.UI.Text maxPlayerText;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void rightClick()
    {
        maxPlayer++;
        if (maxPlayer >= 8)
        {
            maxPlayer = 8;
        }
        maxPlayerText.text = maxPlayer.ToString();
    }
    public void leftClick()
    {
        maxPlayer--;
        if (maxPlayer <= 2)
        {
            maxPlayer = 2;
        }
        maxPlayerText.text = maxPlayer.ToString();
    }
    public void RoomCreateButton()
    {
        panel.SetActive(true);
    }
}
