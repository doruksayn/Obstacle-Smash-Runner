using UnityEngine;

public class obstacleSpawnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pass"))
        {
            FindAnyObjectByType<ObstacleSpawner>().SpawnObstacle();
            FindAnyObjectByType<ObstacleSpawner>().isSecondSet = true;
            Debug.Log("Worked.");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
