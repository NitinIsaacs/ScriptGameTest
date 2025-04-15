using UnityEngine;
public class Trigger : MonoBehaviour
{
    public GameObject gate;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            gate.transform.Rotate(0, 90, 0); // Example: rotate to open
        }
    }
}
