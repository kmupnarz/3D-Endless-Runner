using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Required for TextMeshPro

public class PlayerCollision : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText; // Drag your UI text here in the Inspector

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Collect coins
        if (other.CompareTag("Coin") || other.name.Contains("Coin"))
        {
            score += 10;
            UpdateScoreText();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Hit a hazard
        if (collision.gameObject.CompareTag("Hazard") || collision.gameObject.name.Contains("Hazard"))
        {
            Debug.Log("Game Over! Final Score: " + score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}