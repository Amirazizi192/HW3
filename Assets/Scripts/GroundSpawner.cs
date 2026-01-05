using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform player;

    float spawnZ = 0f;
    float tileLength = 20f;
    int tilesOnScreen = 3;

    void Start()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z - 20f > spawnZ - (tilesOnScreen * tileLength))
        {
            SpawnTile();
        }
    }

    void SpawnTile()
    {
        Instantiate(groundPrefab, Vector3.forward * spawnZ, Quaternion.identity);
        spawnZ += tileLength;
    }
}
