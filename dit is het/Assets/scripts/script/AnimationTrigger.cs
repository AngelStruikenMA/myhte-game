using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    // Reference to the Animator component of the object you want to animate
    public Animator animator;

    // Enum to define different animation triggers
    public enum AnimationTriggerType
    {
        Animation1,
        Animation2
    }

    // Specify the type of animation trigger for this particular trigger collider
    public AnimationTriggerType animationType;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player character
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");

            // Check which animation trigger type this collider represents
            switch (animationType)
            {
                case AnimationTriggerType.Animation1:
                    // Trigger Animation 1
                    animator.SetTrigger("PlayAnimation1");
                    break;
                case AnimationTriggerType.Animation2:
                    // Trigger Animation 2
                    animator.SetTrigger("PlayAnimation2");
                    break;
                default:
                    break;
            }
        }
    }
}
