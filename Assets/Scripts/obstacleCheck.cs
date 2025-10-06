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
                movement.enabled = false;

            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
                rb.linearVelocity = Vector3.zero;
        }
    }
}

/*ublic class obstacleCheck : MonoBehaviour
{
    public BoxCollider obstacle;

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Pass"))
    {
        obstacle.enabled = false;
    }
    else if (other.CompareTag("notPass"))
    {
        obstacle.isTrigger = false;
        GetComponent<ballMovement>().enabled = false;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
    }
}
// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{

}

// Update is called once per frame
void Update()
{

}
}*/
