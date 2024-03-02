using UnityEngine;
using UnityEngine.UI;

public class RGB : MonoBehaviour
{
    [SerializeField] float cycleSpeed = 1.0f;
    [SerializeField] float timeCounter = 0.0f;

    private Image myImage;

    void Start()
    {
        // Get the Image component on the same GameObject
        myImage = GetComponent<Image>();

        // Check if the Image component is found
        if (myImage == null)
        {
            Debug.LogError("Image component not found!");
            return;
        }
    }

    void Update()
    {
        // Increment the time counter using unscaledDeltaTime
        timeCounter += Time.unscaledDeltaTime * cycleSpeed;

        // Calculate an oscillating value between 0 and 1 using Mathf.Sin
        float colorValue = (Mathf.Sin(timeCounter) + 1f) / 2f;

        // Create a rainbow color based on the obtained value
        Color newColor = Color.HSVToRGB(colorValue, 1f, 1f);

        // Set the transparency level
        newColor.a = myImage.color.a;

        // Set the color of the Image to the new color
        myImage.color = newColor;
    }
}
