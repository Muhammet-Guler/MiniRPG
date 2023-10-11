using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour
{
    public GameObject CreateRoomPanel;
    public GameObject RoomsTable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenRoomPanel()
    {
        CreateRoomPanel.SetActive(true);
        RoomsTable.SetActive(false);
    }
    public void AddRooms()
    {
        CreateRoomPanel.SetActive(false);
        RoomsTable.SetActive(true);
    }
}