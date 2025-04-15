using UnityEngine;
public class ContinuousRotation : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 90f, 0); // simple continuous rotation

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
