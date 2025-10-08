using Unity.VisualScripting;
using UnityEngine;

public class planeSpawner : MonoBehaviour
{
    public GameObject newPlane;
    public Transform player;
    public float destroyDelay;
    private bool isSecondPlane;
    private GameObject _newplane;
    public GameObject firstPlane;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("planeSpawner"))
        {
            Debug.Log("Worked Plane Generator.");
            Destroy(firstPlane, destroyDelay);
            isSecondPlane = true;
            SpawnObstacle();
        }
    }

    public void SpawnObstacle()
    {
        // Spawn konumunu hesapla
        Vector3 spawnPos = new Vector3(0, 0, player.position.z + 5.45f);

        GameObject updatedPlane = _newplane;

        // Yeni seti oluştur
        _newplane = Instantiate(newPlane, spawnPos, Quaternion.identity);

        // Eski setleri destroy et
        if (isSecondPlane == true)
        {
            Destroy(updatedPlane, destroyDelay);
            isSecondPlane = false;
            Debug.Log("Destroy plane worked.");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
