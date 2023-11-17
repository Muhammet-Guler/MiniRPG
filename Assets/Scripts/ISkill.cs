using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ISkill:MonoBehaviour
{
    private List<string> SelectedSkills;
    public string description;
    public string skillName;
    public string characterType;
    public void run()
    {
        Invoke(skillName, 0);
    }

    public void createSkill()
    {

    }



}
