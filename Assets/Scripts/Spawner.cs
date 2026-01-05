using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;

    float nextSpawnZ = 15f;

    void Update()
    {
        if (player.position.z + 30f > nextSpawnZ)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        int lane = Random.Range(0, 3);
        float x = (lane - 1) * 2f;

        Instantiate(obstaclePrefab, new Vector3(x, 1, nextSpawnZ), Quaternion.identity);

        nextSpawnZ += Random.Range(3f, 7f);
    }
}
