using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Animator characterAnimator;
    private bool isWalking = false;
    private bool isRunning = false;

    public void OnWalkButtonClick()
    {
        // Toggle walking animation
        isWalking = !isWalking;
        if (isWalking)
        {
            // Start walking animation
            characterAnimator.SetBool("isWalking", true);
            // Ensure running animation is stopped
            characterAnimator.SetBool("isRunning", false);
            isRunning = false;
        }
        else
        {
            // Stop walking animation
            characterAnimator.SetBool("isWalking", false);
        }
    }

    public void OnRunButtonClick()
    {
        // Toggle running animation
        isRunning = !isRunning;
        if (isRunning)
        {
            // Start running animation
            characterAnimator.SetBool("isRunning", true);
            // Ensure walking animation is stopped
            characterAnimator.SetBool("isWalking", false);
            isWalking = false;
        }
        else
        {
            // Stop running animation
            characterAnimator.SetBool("isRunning", false);
        }
    }
}
