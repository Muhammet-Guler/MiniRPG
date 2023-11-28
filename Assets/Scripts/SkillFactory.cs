using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFactory : MonoBehaviour
{
    public List<ISkill> allSkillList;
    public List<ISkill> AllSelectableSkillList;

    public void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCharacterSkills(ICharacter character)
    {        

        for (int i = 0; i < AllSkills.Skillist.Count; i++)
        {
            Debug.Log("characterType:"+character.characterType);
            if (character.characterType == AllSkills.Skillist[i].characterType)
            {
                character.skillList.Add(AllSkills.Skillist[i]);
                Debug.Log("skillist:" + character.skillList);

            }
           
        }
        
    }
}
