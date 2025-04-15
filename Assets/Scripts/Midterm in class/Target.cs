using UnityEngine;

public enum TargetType
{
    Destroyable,
    Movable,
    DestroyableWithSound
}

public class Target : MonoBehaviour
{
    public AudioSource targetSound;                  // Audio to play when the target is destroyed
    public TargetType targetType;                    // The type of target behavior
    private Vector3 startingPosition;                // Original position of the target
    public float maxMovingTargetRange = 3f;          // Range within which movable targets can relocate

    void Start()
    {
        startingPosition = transform.position;       // Record the original position

        // Set target color based on its type
        if (targetType == TargetType.Destroyable)
        {
            GetComponent<MeshRenderer>().material.color = Color.magenta;
        }
        else if (targetType == TargetType.Movable)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (targetType == TargetType.DestroyableWithSound)
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Check if collided object is tagged as "Bullet"
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Destroy bullet immediately upon collision

            if (targetType == TargetType.Destroyable)
            {
                gameObject.SetActive(false); // Deactivate the target
            }
            else if (targetType == TargetType.Movable)
            {
                // Randomly reposition within a defined range
                float randomY = Random.Range(-maxMovingTargetRange, maxMovingTargetRange);
                float randomZ = Random.Range(-maxMovingTargetRange, maxMovingTargetRange);

                transform.position = startingPosition + new Vector3(0f, randomY, randomZ);
            }
            else if (targetType == TargetType.DestroyableWithSound)
            {
                targetSound.Play();          // Play destruction audio bite
                gameObject.SetActive(false); // Deactivate the target after playing audio
            }
        }
    }
}
