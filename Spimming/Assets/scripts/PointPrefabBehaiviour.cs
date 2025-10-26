using UnityEngine;

public class PointPrefabBehaviour : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Rotation Settings")]
    public float rotationSpeed = 50f;
    public bool randomizeSpin = true;

    [Header("Score Settings")]
    public int scoreValue = 10;

    private float spinDirection = 1f;

    void Start()
    {
        if (randomizeSpin)
        {
            spinDirection = Random.value < 0.5f ? -1f : 1f;
            rotationSpeed *= Random.Range(0.5f, 1.5f);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * rotationSpeed * spinDirection * Time.deltaTime);

        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(scoreValue);
            }

            Destroy(gameObject);
        }
    }
}
