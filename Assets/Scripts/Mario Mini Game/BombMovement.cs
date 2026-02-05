using UnityEngine;
using System.Collections;
public class BombMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float changeInterval = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            Debug.Log("Has rigidbody");
        }
        StartCoroutine(ChangeDirectionRoutine());
    }

    IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            // randomise direction of movement
            Vector3 randomDir = Random.onUnitSphere;

            //randomDir.y = 0;
            //randomDir.Normalize();

            // Set velocity
            rb.linearVelocity = randomDir * moveSpeed;

            // Waits for the specified interval before choosing a new direction
            yield return new WaitForSeconds(changeInterval);
        }
    }
}