using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterSkills : MonoBehaviourPunCallbacks
{
    private List<string> SelectedSkills;
    public List<Skills> skillList;
    public Animator CharacterAnimation;
    Skills skill;
    void Start()
    {        
    }
    
    void Update()
    {
          
    }
    private List<string> getSelectedSkills()
    {
       
        return this.SelectedSkills;
    }



    public void useSkill(Skills skill)
    {

        CharacterAnimation.Play(skill.Name);
        Invoke(skill.Name,skill.coolDown);
    }
    public void addSelectedSkills(string skillName)
    {
        this.SelectedSkills.Add(skillName);
        skill.createSkill(skillName);
        this.skillList.Add(skill);

    }

}
