using Unity.VisualScripting;
using UnityEngine;

public class newWorldSpawner : MonoBehaviour
{
    public GameObject newPlane;
    public Transform player;
    public float destroyDelay;
    private bool isSecondPlane;
    private GameObject _newWorld;
    public GameObject firstWorld;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("worldSpawner"))
        {
            Debug.Log("Worked World Generator.");
            Destroy(firstWorld, destroyDelay);
            isSecondPlane = true;
            SpawnWorld();
        }
    }

    public void SpawnWorld()
    {
        // Spawn konumunu hesapla
        Vector3 spawnPos = new Vector3(0, 0, player.position.z + 300f);

        GameObject updatedPlane = _newWorld;

        // Yeni seti oluştur
        _newWorld = Instantiate(newPlane, spawnPos, Quaternion.identity);

        // Eski setleri destroy et
        if (isSecondPlane == true)
        {
            Destroy(updatedPlane, destroyDelay);
            isSecondPlane = false;
            Debug.Log("Destroy world worked.");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
