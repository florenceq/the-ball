using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePowerUp : MonoBehaviour
{
    
    public float fadeInTime = 1f;
    public float spinSpeed = 30f;
    public float lifeTime = 15f;

    private float startTime;
    private bool isClicked = false;

    void Start()
    {
        startTime = Time.time;
        // Start fading in
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);

        if (!isClicked && Time.time - startTime > lifeTime)
        {
            // Fade out if not clicked within the lifetime
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color startColor = new Color(1f, 1f, 1f, 0f);
        Color endColor = Color.white;

        while (elapsedTime < fadeInTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeInTime);
            GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float fadeOutTime = 1f;
        float elapsedTime = 0f;
        Color startColor = Color.white;
        Color endColor = new Color(1f, 1f, 1f, 0f);

        while (elapsedTime < fadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeOutTime);
            GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        // Handle click event
        isClicked = true;
        // Play video, change cursor appearance, and modify ball behavior
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        // Add code to play video here
        // Example: Handled by VideoPlayer component
        yield return null;

        // Change cursor appearance and modify ball behavior here
        // Example: ChangeCursorAppearance(), ModifyBallBehavior()
    }
}

