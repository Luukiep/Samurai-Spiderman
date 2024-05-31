using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cama : MonoBehaviour
{
    public float scrollSpeed = 10f;
    public Transform target;
    public float minDistance = 5f;
    public float maxDistance = 20f;

    private float currentDistance;

    void Start()
    {
        if (target != null)
        {
            // Calculate initial distance from the target
            currentDistance = Vector3.Distance(transform.position, target.position);
        }
        else
        {
            Debug.LogError("Target not set for CameraMover script.");
        }
    }

    void Update()
    {
        if (target == null) return;

        // Get the input from the scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        // Update the current distance based on the scroll input
        currentDistance = Mathf.Clamp(currentDistance - scroll, minDistance, maxDistance);

        // Calculate the new position
        Vector3 direction = (transform.position - target.position).normalized;
        Vector3 newPosition = target.position + direction * currentDistance;

        // Ensure the camera does not get too close to the target
        if (currentDistance > minDistance)
        {
            // Set the camera's position to the new position
            transform.position = newPosition;
        }

        // Keep the camera facing the target
        transform.LookAt(target);
    }
}
