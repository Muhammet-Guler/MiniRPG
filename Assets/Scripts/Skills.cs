using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public string Name;
    public int coolDown;
    private string effectType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void createSkill(string name)
    {
        Invoke(name,0);
    }

    public void Skill_Spike()
    {
        this.Name = "Attack1 0";
        this.coolDown = 5;
        this.effectType = "Attack";
        Debug.Log("skillSPike calisti");
    }
    public void Skill_Attack()
    {
        this.Name = "Attack1 1";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
    public void Skill_Attack2()
    {
        this.Name = "Attack1 2";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
    public void Skill_Attack3()
    {
        this.Name = "Attack1 3";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
    public void Skill_Attack4()
    {
        this.Name = "Attack1 4";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
    public void Skill_Attack5()
    {
        this.Name = "Attack1 5";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
    public void Skill_Attack6()
    {
        this.Name = "Attack1 6";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
    public void Skill_Attack7()
    {
        this.Name = "Punch 0";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
    public void Skill_Attack8()
    {
        this.Name = "Punch 1";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
    public void Skill_Attack9()
    {
        this.Name = "Punch";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
    public void Skill_Attack10()
    {
        this.Name = "SpinAttack_TwoWeapons";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
    public void Skill_Attack11()
    {
        this.Name = "MeeleeAttack_TwoHanded";
        this.coolDown = 5;
        this.effectType = "Attack";
    }
}
