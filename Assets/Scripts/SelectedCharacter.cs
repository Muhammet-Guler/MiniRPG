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
        Characters[0].SetActive(false);
        Characters[1].SetActive(false);
        Characters[2].SetActive(false);
        Characters[3].SetActive(false); 
        chooseCharacter = PlayerPrefs.GetInt("selectedOption");
        for (int i = 0; i <= chooseCharacter; i++)
        {
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
