using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.right * 200f, ForceMode.Impulse);
        }
    }
}