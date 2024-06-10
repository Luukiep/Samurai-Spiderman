using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cama : MonoBehaviour
{
    public Transform pointA; // The first point
    public Transform pointB; // The second point
    public float scrollSpeed = 1.0f; // Speed at which the camera moves
    public float minDistanceFromPointB = 1.0f; // Minimum distance to maintain from point B

    private float scrollInput = 0.0f; // Value to store the scroll input
    private float maxScrollInput; // Maximum scroll input based on minDistanceFromPointB

    void Start()
    {
        // Calculate the maximum scroll input based on the minimum distance
        float totalDistance = Vector3.Distance(pointA.position, pointB.position);
        maxScrollInput = 1.0f - (minDistanceFromPointB / totalDistance);
    }

    void Update()
    {
        // Get the scroll wheel input
        scrollInput += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        // Clamp the input value to be between 0 and maxScrollInput
        scrollInput = Mathf.Clamp(scrollInput, 0.0f, maxScrollInput);

        // Interpolate the camera's position between point A and point B
        transform.position = Vector3.Lerp(pointA.position, pointB.position, scrollInput);
    }
}
