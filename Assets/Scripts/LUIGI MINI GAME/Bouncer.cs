using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 direction;

    void Start()
    {
        // Choose a random direction in xy
        direction = Random.insideUnitSphere;
        direction.z = 0; // Lock to XY plane
        direction.Normalize(); // Normalize to ensure consistent speed
    }

    void Update()
    {
        // Move the object each frame
        transform.Translate(direction * speed * Time.deltaTime);

        // Convert position to viewport coordinates (0 to 1 range)
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // Bounce horizontally if hitting left or right edges
        if (viewPos.x < 0f || viewPos.x > 1f)
            direction.x *= -1;

        // Bounce vertically if hitting top or bottom
        if (viewPos.y < 0f || viewPos.y > 1f)
            direction.y *= -1;
    }
}