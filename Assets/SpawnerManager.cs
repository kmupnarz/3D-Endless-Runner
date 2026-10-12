using UnityEngine;

/// <summary>
/// Handles spawning hazards and coins ahead of the player while dynamically scaling difficulty over time.
/// Implements the algorithm designed in Task 2.
/// </summary>
public class SpawnerManager : MonoBehaviour
{
    [Header("Target References")]
    public Transform playerTransform;
    public GameObject hazardPrefab;
    public GameObject coinPrefab;

    [Header("Spawn Configuration")]
    public float spawnInterval = 2.0f;
    public float spawnDistanceAhead = 30.0f;
    public float laneDistance = 3.0f;

    [Header("Difficulty Scaling")]
    public float minimumSpawnInterval = 0.6f;
    public float difficultyScaleRate = 0.01f;

    private float timer = 0.0f;

    void Update()
    {
        if (playerTransform == null) return;

        // Step 1: Track elapsed time
        timer += Time.deltaTime;

        // Step 2: Spawn objects at designated intervals
        if (timer >= spawnInterval)
        {
            timer = 0.0f;
            SpawnRandomObject();
        }

        // Step 3: Dynamic Difficulty Scaling
        if (spawnInterval > minimumSpawnInterval)
        {
            spawnInterval -= difficultyScaleRate * Time.deltaTime;
        }
    }

    /// <summary>
    /// Selects a random lane (-1: Left, 0: Center, 1: Right) and spawns either a hazard or coin.
    /// </summary>
    void SpawnRandomObject()
    {
        // Select random lane index (-1, 0, or 1)
        int laneIndex = Random.Range(-1, 2);

        // Calculate spawn coordinates relative to the player
        Vector3 spawnPos = new Vector3(
            laneIndex * laneDistance,
            0.5f,
            playerTransform.position.z + spawnDistanceAhead
        );

        // 70% chance for Hazard, 30% chance for Coin
        float randomVal = Random.value;
        if (randomVal > 0.3f)
        {
            if (hazardPrefab != null) Instantiate(hazardPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            if (coinPrefab != null) Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }
}