using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFactory : MonoBehaviour
{
    public List<ISkill> allSkillList;
    public List<ISkill> AllSelectableSkillList;
    public void Start()
    {
        AllSkills allSkill=new AllSkills();
        for (int i = 0; i < allSkill.allSkills.Count; i++)
        {
            Invoke(allSkill.allSkills[i],0);
            ISkill skill = allSkill;
            allSkillList.Add(skill);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public List<ISkill> getSelectableSkills(ICharacter character)
    {

        for (int i = 0; i < allSkillList.Count; i++)
        {
            AllSelectableSkillList = null;
            if (character.characterName == allSkillList[i].characterType) 
            {
                AllSelectableSkillList.Add(allSkillList[i]);
            }
            
        }
        return AllSelectableSkillList;
    }
}
