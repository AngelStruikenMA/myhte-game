using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentingTrigger : MonoBehaviour
{
    // Reference to the object to which the player will be parented
    public Transform parentObject;

    // Flag to keep track of whether the player is currently parented
    private bool isPlayerParented = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player character
        if (other.CompareTag("Player") && !isPlayerParented)
        {
            // Parent the player character to the parentObject
            other.transform.parent = parentObject;
            isPlayerParented = true;
            Debug.Log("Player is now parented to " + parentObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object that exited the trigger is the player character
        if (other.CompareTag("Player") && isPlayerParented)
        {
            // Un-parent the player character
            other.transform.parent = null;
            isPlayerParented = false;
            Debug.Log("Player is now unparented.");
        }
    }
}

