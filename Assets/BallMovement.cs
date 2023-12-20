using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float bounceForce;
    private Rigidbody2D rb;

    public float speed = 5f;
    private bool isPowerUpActive = false; // Add this variable to track power-up status
    private bool isClickable = true; // New flag to track clickability

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;

        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            rb.velocity = new Vector2(-rb.velocity.x * bounceForce, rb.velocity.y);
        }
        if (transform.position.y <= minY || transform.position.y >= maxY)
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y * bounceForce);
        }
    }

    public void ActivatePowerUp()
    {
        isPowerUpActive = true;
        // Add any other logic for power-up activation...
    }

    public void DeactivatePowerUp()
    {
        isPowerUpActive = false;
        // Add any other logic for power-up deactivation...
    }

    private void OnMouseDown()
    {
        // Check if the power-up is not active before responding to the click
        if (!isPowerUpActive && isClickable)
        {
            // Enlarge the ball and cover the whole screen
            EnlargeBall();
        }
    }

    private void EnlargeBall()
    {
        // Disable the collider to prevent further clicks while the ball is enlarging
        GetComponent<Collider2D>().enabled = false;

        // Enlarge the ball gradually
        float targetScale = 10f; // Adjust this value based on your needs
        float duration = 2f; // Adjust this value based on your needs
        StartCoroutine(ScaleOverTime(transform.localScale, Vector3.one * targetScale, duration));
    }

    private IEnumerator ScaleOverTime(Vector3 startScale, Vector3 endScale, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;

        // Assuming you want to do something else after enlarging the ball
        // For example, you can load a new scene, show a game over screen, etc.
        // Replace this with your desired logic.
        Debug.Log("Ball enlarged. Add your post-enlargement logic here.");
    }
}