using UnityEngine;

public class PushOnCollision : MonoBehaviour
{
    public float pushForce = 10f;
    private void OnCollisionEnter(Collision collision)
    {
        // to check for Rigidbody
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            // Get the direction from the object to the ball
            Vector3 pushDirection = (collision.transform.position - transform.position).normalized;

            // Apply force to the ball
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
