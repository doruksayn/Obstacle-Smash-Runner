using Unity.VisualScripting;
using UnityEngine;

public class planeSpawner : MonoBehaviour
{
    public GameObject newPlane;
    public Transform player;           // top objesi  
    public float destroyDelay = 10f;   // eski setin yok olma süresi

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("planeSpawner"))
        {

            Debug.Log("Worked Plane Generator.");
            SpawnObstacle();

        }
    }

    public void SpawnObstacle()
    {

        // Spawn konumunu hesapla
        Vector3 spawnPos = new Vector3(0, 0, player.position.z + 5.5f);

        // Yeni seti oluştur
        GameObject _newplane = Instantiate(newPlane, spawnPos, Quaternion.identity);

        // Eski setleri destroy et
        // Destroy(newSet, destroyDelay);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
