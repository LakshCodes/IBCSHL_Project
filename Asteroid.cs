using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth == null) {return;}
        
            playerHealth.Crash();
        
    }

    priavte void private void OnBecameInvisible() 
    {
        Destroy(GameObject);
    }
}
