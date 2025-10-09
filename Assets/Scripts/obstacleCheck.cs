using UnityEngine;

public class obstacleCheck : MonoBehaviour
{
    public void HandleCollision(GameObject hitObstacle, GameObject player)
    {
        if (hitObstacle.CompareTag("Pass"))
        {
            // Çocuk obstacle collider'ını kapat, top geçebilir
            hitObstacle.GetComponent<Collider>().enabled = false;
            Debug.Log("Geçilebilir engelden geçildi!");
        }
        else if (hitObstacle.CompareTag("notPass"))
        {
            // Top çarptı, durdur
            Debug.Log("Engel çarpması!");
            var movement = player.GetComponent<ballMovement>();
            if (movement != null)
            {
                movement.enabled = false;
            }

            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
