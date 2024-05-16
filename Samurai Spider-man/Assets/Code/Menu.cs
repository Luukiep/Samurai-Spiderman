using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Animator characterAnimator;
    public GameObject targetObject; // The target GameObject to rotate
    public float rotationSpeed = 2.0f; // Adjust this value for faster or slower rotation

    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;


    private bool isWalking = false;
    private bool isRunning = false;


    public void Update()
    {
        if (targetObject != null)
        {
            if (isRotatingLeft)
            {
                targetObject.transform.Rotate(0, -rotationSpeed * Time.deltaTime * 90, 0);
            }
            else if (isRotatingRight)
            {
                targetObject.transform.Rotate(0, rotationSpeed * Time.deltaTime * 90, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }
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

    public void ToggleRotateLeft()
    {
        if (isRotatingLeft)
        {
            isRotatingLeft = false; // Stop rotating left
        }
        else
        {
            isRotatingLeft = true; // Start rotating left
            isRotatingRight = false; // Stop rotating right if it was active
        }
    }

    public void ToggleRotateRight()
    {
        if (isRotatingRight)
        {
            isRotatingRight = false; // Stop rotating right
        }
        else
        {
            isRotatingRight = true; // Start rotating right
            isRotatingLeft = false; // Stop rotating left if it was active
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
