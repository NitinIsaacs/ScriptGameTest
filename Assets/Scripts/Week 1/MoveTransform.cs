using UnityEngine;
using System.Collections;

public class MoveTransform : MonoBehaviour
{
    // Adjustable parameters
    public float moveSpeed = 3f;         // Speed at which the object moves
    public float jumpHeight = 2f;        // How high the jump is
    public float jumpDuration = 0.5f;    // Total time taken for the jump (up and down)
    public float waitTime = 1f;          // Time to wait after reaching a target before jumping/moving again
    public float movementRange = 5f;     // Range for random target positions on the x and z axes

    void Start()
    {
        // Start at the origin
        transform.position = Vector3.zero;
        // Begin the movement routine
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            // Pick a new random target position on the floor (y stays at 0)
            Vector3 targetPosition = new Vector3(Random.Range(-movementRange, movementRange), 0f, Random.Range(-movementRange, movementRange));

            // Move towards the target position gradually
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Once reached, perform a jump
            yield return StartCoroutine(JumpRoutine());

            // Wait a moment before choosing the next target
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator JumpRoutine()
    {
        Vector3 startPosition = transform.position;
        Vector3 apexPosition = startPosition + Vector3.up * jumpHeight;

        // Jump up (first half of the duration)
        float halfDuration = jumpDuration / 2f;
        float elapsed = 0f;
        while (elapsed < halfDuration)
        {
            transform.position = Vector3.Lerp(startPosition, apexPosition, elapsed / halfDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        // Ensure the apex is reached
        transform.position = apexPosition;

        // Jump down (second half of the duration)
        elapsed = 0f;
        while (elapsed < halfDuration)
        {
            transform.position = Vector3.Lerp(apexPosition, startPosition, elapsed / halfDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        // Ensure the object is back at its starting position
        transform.position = startPosition;
    }
}

