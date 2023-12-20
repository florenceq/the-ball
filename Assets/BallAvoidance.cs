using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAvoidance : MonoBehaviour
{

        public Transform playerCursor;
    public float avoidanceSpeed = 5f;
    public float avoidanceFactor = 1.0f;

    private void Update()
    {
        Vector3 direction = transform.position - playerCursor.position;
        transform.Translate(direction.normalized * avoidanceSpeed * Time.deltaTime);
    }

    public void DecreaseAvoidance()
    {
        // Implement code to decrease the avoidanceFactor
        avoidanceFactor *= 0.5f;  // Adjust the factor as needed
    }

}





