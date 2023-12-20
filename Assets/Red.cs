using System.Collections;
using UnityEngine;

public class Red : MonoBehaviour
{
    public float fadeDuration = 30f;    // Adjust this as needed
    public float stayDuration = 15f;   // Adjust this as needed
    public GameObject Ball;            // Reference to your ball GameObject
    public Texture2D newCursor;        // The new cursor texture

    private BallAvoidance ballAvoidance;    // Reference to the BallAvoidance script
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component

        // Attempt to get the BallAvoidance script from the ball GameObject
        ballAvoidance = Ball.GetComponent<BallAvoidance>();

        if (ballAvoidance == null)
        {
            Debug.LogError("BallAvoidance script not found on the ball GameObject.");
        }

        StartCoroutine(DisplayElement());
    }

    
    

    IEnumerator DisplayElement()
    {
        // Fade-in
        float elapsedTime = 0f;
        Color startColor = new Color(1f, 1f, 1f, 0f);  // Starting color with zero alpha
        Color targetColor = new Color(1f, 1f, 1f, 1f);  // Target color with full alpha

        while (elapsedTime < fadeDuration)
        {
            spriteRenderer.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

         spriteRenderer.color = targetColor;  // Ensure the element is fully visible

        // Stay visible for 20 seconds
        yield return new WaitForSeconds(stayDuration);

        // Fade-out
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color startColor = new Color(1f, 1f, 1f, 1f);  // Starting color with full alpha
        Color targetColor = new Color(1f, 1f, 1f, 0f);  // Target color with zero alpha

        while (elapsedTime < fadeDuration)
        {
            spriteRenderer.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = targetColor;  // Ensure the element is fully transparent

        // Deactivate the clickable element
        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        AdjustAvoidance();
        ChangeCursorAppearance();
        Destroy(gameObject);  // Remove the element after it is clicked
    }

    void AdjustAvoidance()
    {
        // Implement code to adjust the avoidance behavior in BallAvoidance script
        if (ballAvoidance != null)
        {
            ballAvoidance.DecreaseAvoidance();  // Adjust the method name as needed
        }
    }

    void ChangeCursorAppearance()
    {
        // Implement code to change cursor appearance
        Cursor.SetCursor(newCursor, Vector2.zero, CursorMode.Auto);
    }
}
