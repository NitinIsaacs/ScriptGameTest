using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public GameObject bombPrefab;
    public Button startButton;
    public TMP_Text timerText;
    public TMP_Text countText;
    public TMP_Text resultText;

    [Header("Game Settings")]
    // Round will last 60 seconds can change (wanted to set different time modes but ran out of time lol (irony ;-;))
    public float gameDuration = 60f;

    [Header("Level Bounds Settings")]
    public Vector3 levelMin;                    // Min bounds for spawning
    public Vector3 levelMax;                    // Max bounds for spawning
    public float minDistanceBetweenBombs = 2f;  // Min distance between spawns

    private List<GameObject> bombs = new List<GameObject>();
    private bool gameStarted = false;
    private float timeRemaining;
    private int maxSpawnAttempts = 10;
    private int playerCount = 0;

    void Start()
    {
        // Hook up the Start button click event.
        startButton.onClick.AddListener(StartGame);
        // Initialize UI elements.
        UpdatePlayerCountUI();
        resultText.text = "";
    }

    void Update()
    {
        if (gameStarted && timeRemaining > 0)
        {
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerCount++;
                UpdatePlayerCountUI();
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerCount = Mathf.Max(0, playerCount - 1);
                UpdatePlayerCountUI();
            }
        }
    }

    void UpdatePlayerCountUI()
    {
        countText.text = "" + playerCount;
    }

    void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            startButton.interactable = false;
            SpawnBombs();
            timeRemaining = gameDuration;
            StartCoroutine(GameTimer());
            StartCoroutine(ScheduleExplosions());
        }
    }

    void SpawnBombs()
    {
        // This will Spawn bombs (Random number (20-40)).
        int count = Random.Range(20, 41);
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = GetRandomPosition();
            GameObject bomb = Instantiate(bombPrefab, spawnPos, Quaternion.identity);
            bomb.name = "bomb";
            bombs.Add(bomb);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 pos = Vector3.zero;
        bool validPosition = false;
        int attempts = 0;
        while (!validPosition && attempts < maxSpawnAttempts)
        {
            // Choose a random position within the level bounds.
            pos = new Vector3(
                Random.Range(levelMin.x, levelMax.x),
                Random.Range(levelMin.y, levelMax.y),
                Random.Range(levelMin.z, levelMax.z)
            );

            validPosition = true;
            // Check that the position is not too close to any existing bomb.
            foreach (GameObject existingBomb in bombs)
            {
                if (existingBomb != null && Vector3.Distance(existingBomb.transform.position, pos) < minDistanceBetweenBombs)
                {
                    validPosition = false;
                    break;
                }
            }
            attempts++;
        }
        return pos;
    }

    IEnumerator GameTimer()
    {
        while (timeRemaining > 0)
        {
            timerText.text = "Time Left: " + Mathf.CeilToInt(timeRemaining).ToString();
            timeRemaining -= Time.deltaTime;
            yield return null;
        }
        timerText.text = "Time Left: 0";
        EndGame();
    }

    IEnumerator ScheduleExplosions()
    {
        // Continue scheduling explosions while time remains.
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(Random.Range(3f, 10f));

            List<GameObject> remainingBombs = bombs.FindAll(b => b != null);
            if (remainingBombs.Count > 0)
            {
                GameObject chosenBomb = remainingBombs[Random.Range(0, remainingBombs.Count)];
                StartCoroutine(ExplodeBombAfterDelay(chosenBomb, 3f));
            }
        }
    }

    IEnumerator ExplodeBombAfterDelay(GameObject bomb, float delay)
    {
        // Change bomb color to red as a warning.
        Renderer rend = bomb.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.red;
        }
        yield return new WaitForSeconds(delay);

        // If the bomb still exists, trigger its explosion.
        if (bomb != null)
        {
            BombBehavior behavior = bomb.GetComponent<BombBehavior>();
            if (behavior != null)
            {
                behavior.Explode();
            }
            else
            {
                Destroy(bomb);
            }
        }
    }

    void EndGame()
    {
        // Count the remaining bombs.
        int countLeft = bombs.FindAll(b => b != null).Count;
        // Compare with the player's count.
        if (playerCount == countLeft)
        {
            resultText.text = "You Win c; | Bombs Left: " + countLeft + " | Your Count: " + playerCount;
        }
        else
        {
            resultText.text = "You Lose :c | Bombs Left: " + countLeft + " | Your Count: " + playerCount;
        }
    }
}