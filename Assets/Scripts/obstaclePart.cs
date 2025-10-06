using UnityEngine;

public class ObstaclePart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("isPlayer"))
        {
            // Parent içindeki ObstacleCheck script'ini çağır
            Debug.Log(this.gameObject.name + other.gameObject.name + "hello");
            GetComponentInParent<obstacleCheck>()?.HandleCollision(this.gameObject, other.gameObject);

        }
    }
}

