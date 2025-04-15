using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;

    public void SpawnBall()
    {
        if (spawnPoint != null && ballPrefab != null)
        {
            Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Ball prefab or spawn point not set!");
        }
    }
}
