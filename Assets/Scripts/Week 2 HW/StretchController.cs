using UnityEngine;

public class StretchController : MonoBehaviour
{
    public Transform objectToStretch;
    public float stretchAmount = 0.2f;
    public float maxStretch = 3f;
    public float minStretch = 0.2f;

    // Stretch with Right button to increase scale
    public void StretchRight()
    {
        Vector3 scale = objectToStretch.localScale;
        scale.x = Mathf.Min(scale.x + stretchAmount, maxStretch);
        objectToStretch.localScale = scale;
    }

    // Stretch with Left button to decrease scale
    public void StretchLeft()
    {
        Vector3 scale = objectToStretch.localScale;
        scale.x = Mathf.Max(scale.x - stretchAmount, minStretch);
        objectToStretch.localScale = scale;
    }
}
