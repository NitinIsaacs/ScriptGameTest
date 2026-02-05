using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject luigiPrefab;
    public GameObject[] otherPrefabs;

    [Header("Spawn Settings")]
    public int numberOfOthers = 20;
    public Vector2 spawnAreaMin = new Vector2(-8, -4);
    public Vector2 spawnAreaMax = new Vector2(8, 4);

    void Start()
    {
        SpawnLuigi();      // Spawns one Luigi
        SpawnOthers();     // Spawns the rest
    }

    void SpawnLuigi()
    {
        Vector2 pos = GetRandomPosition(); // Get random spawn location
        Instantiate(luigiPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
    }

    void SpawnOthers()
    {
        for (int i = 0; i < numberOfOthers; i++)
        {
            // Randomly pick a character from the array
            GameObject randomOther = otherPrefabs[Random.Range(0, otherPrefabs.Length)];

            // used to avoid accidentally spawning an extra Luigi
            if (randomOther == luigiPrefab) continue;

            Vector2 pos = GetRandomPosition();
            Instantiate(randomOther, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        }
    }

    // Generates a random position between the min and max bounds
    Vector2 GetRandomPosition()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        return new Vector2(x, y);
    }
}