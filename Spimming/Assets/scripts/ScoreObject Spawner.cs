using UnityEngine;

public class ScoreObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform Min;
    [SerializeField] private Transform Max;

    public GameObject prefab;
    public float spawnTimer;
    public float spawnInterval;

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            SpawnObject();
        }
    }
    private void SpawnObject()
    {
        Instantiate(prefab, RandomSpawnPoint(), transform.rotation);
    }

    private Vector2 RandomSpawnPoint()
    {
        Vector2 spawnPoint;

        spawnPoint.x = Min.position.x;
        spawnPoint.y = Random.Range(Min.position.y, Max.position.y);

        return spawnPoint;
    }
}
