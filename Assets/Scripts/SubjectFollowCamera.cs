using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectFollowCamera : MonoBehaviour
{
    public Transform ball; 
    public Vector3 offset = new Vector3(0, 5, -10); 
    public float smoothSpeed = 10f; 

    void LateUpdate()
    {
        if (ball != null)
        {
            Vector3 targetPosition = ball.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            transform.LookAt(ball.position);

            Debug.Log("Camera Position: " + transform.position);
        }
        else
        {
            Debug.LogWarning("Ball is not assigned!");
        }
    }
}
