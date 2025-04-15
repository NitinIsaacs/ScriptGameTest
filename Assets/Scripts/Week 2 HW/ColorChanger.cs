using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer sphereRenderer;

    // assigns a random color to the sphere
    public void ChangeToRandomColor()
    {
        Color randomColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );

        sphereRenderer.material.color = randomColor;
    }
}