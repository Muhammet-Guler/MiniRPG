using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    public ISkill iskill;
    void Start()
    {
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            TargetHandler targetHandler = other.gameObject.GetComponent<TargetHandler>();
            if (targetHandler != null&&other.gameObject.name!= gameObject.name)
            {
                targetHandler.TakeDamage(0.2f); // damageAmount, �arp��man�n ne kadar zarar verdi�ini belirten bir de�er olmal�.
            }
        }

        Debug.Log("otherGameobject"+other.gameObject.name);
    }
    public void OnCollisionEnter(Collision collision)
    {
        
    }
}
