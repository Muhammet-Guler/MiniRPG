using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Player : MonoBehaviourPun
{
    void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            TargetHandler targetHandler = other.gameObject.GetComponent<TargetHandler>();
            if (targetHandler != null&&other.gameObject.name!= gameObject.name)
            {
                targetHandler.TakeDamage(0.2f, other.gameObject.GetComponent<ICharacter>());
            }
        }

        Debug.Log("otherGameobject"+other.gameObject.name);
    }
    public void OnCollisionEnter(Collision collision)
    {
        
    }
}
