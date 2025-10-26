using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip destroySound;
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            TriggerGameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
            TriggerGameOver();
    }

    private void TriggerGameOver()
    {
        if (destroySound != null)
            AudioSource.PlayClipAtPoint(destroySound, transform.position);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
}

