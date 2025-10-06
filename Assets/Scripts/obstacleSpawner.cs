using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacleSets;  // 3’lü prefab setleri buraya sürükle
    public Transform player;           // top objesi
    public float spawnDistance = 30f;  // yeni setin topun önüne ekleneceği mesafe
    public float destroyDelay = 0.5f;   // eski setin yok olma süresi

    private float lastSpawnZ = 5f;

    private GameObject newSet;

    public bool isSecondSet;          // son spawn konumu (Z ekseni)

    void Start()
    {
        Debug.Log(isSecondSet);
        SpawnObstacle();
    }

    public void SpawnObstacle()
    {
        // Rastgele bir engel seti seç
        int randIndex = Random.Range(0, obstacleSets.Length);

        // Spawn konumunu hesapla
        Vector3 spawnPos = new Vector3(0, 0, player.position.z + 0.5f);

        GameObject updatedSet = newSet;

        // Yeni seti oluştur
        newSet = Instantiate(obstacleSets[randIndex], spawnPos, Quaternion.identity);

        if (isSecondSet == true)
        {
            // Eski setleri destroy et
            Destroy(updatedSet, destroyDelay);
            isSecondSet = false;
        }


        // Spawn konumunu güncelle
        lastSpawnZ += spawnDistance;
    }
}

/*using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform player;
    public float spawnDistance = 0.5f;
    public float destroyDelay = 0.3f;

    private float lastSpawnZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void spawnObstacle()
    {
        // Rastgele bir engel seti seç
        int randIndex = Random.Range(0, obstacles.Length);

        // Spawn konumunu hesapla
        Vector3 spawnPos = player.position + player.forward * spawnDistance;

        // Yeni seti oluştur
        GameObject newSet = Instantiate(obstacles[randIndex], spawnPos, Quaternion.identity);

        // Eski setleri destroy et
        //Destroy(newSet, destroyDelay);

        // Spawn konumunu güncelle
        lastSpawnZ += spawnDistance;
    }
}
*/