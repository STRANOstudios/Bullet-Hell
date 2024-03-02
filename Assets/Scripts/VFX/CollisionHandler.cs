using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float fadeDuration = 2.0f; // Duration of fading in seconds

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Execute specific actions for enemy collision
            // ...

            

            StartCoroutine(BlinkEffect());
        }
    }

    private IEnumerator BlinkEffect()
    {
        // Get the renderer of the GameObject (assuming there is a renderer)
        Renderer renderer = GetComponent<Renderer>();

        // Check if the renderer is valid
        if (renderer != null)
        {
            // Initial opacity
            float startOpacity = renderer.material.color.a;

            // Elapsed time
            float elapsedTime = 0f;

            while (elapsedTime < fadeDuration)
            {
                // Calculate the new opacity based on elapsed time
                float newOpacity = Mathf.Lerp(startOpacity, 0f, elapsedTime / fadeDuration);

                // Set the new opacity in the material color
                Color newColor = renderer.material.color;
                newColor.a = newOpacity;
                renderer.material.color = newColor;

                // Update elapsed time
                elapsedTime += Time.deltaTime;

                // Wait until the next frame
                yield return null;
            }

            // Ensure opacity is set to zero at the end
            Color finalColor = renderer.material.color;
            finalColor.a = 0f;
            renderer.material.color = finalColor;
        }
    }
}
