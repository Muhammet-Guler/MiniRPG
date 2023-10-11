using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public int chooseCharacter;
    public GameObject[] Characters;
    void Start()
    {
        chooseCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        for (int i = 0; i <= Characters.Length; i++)
        {
            Characters[i].SetActive(false);
            if (chooseCharacter == i)
            {
                Characters[i].SetActive(true);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
