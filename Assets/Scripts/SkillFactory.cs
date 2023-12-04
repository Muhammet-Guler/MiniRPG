using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFactory : MonoBehaviour
{
    public void Start()
    {

    }
    void Update()
    {
        
    }

    public ICharacter addCharacterSkills(ICharacter character)
    {
        for (int i = 0; i < AllSkills.Skillist.Count; i++)
        {
            if (character.characterType == AllSkills.Skillist[i].characterType)
            {
                character.skillList.Add(AllSkills.Skillist[i]);
            }
        }
        return character;
    }
}
