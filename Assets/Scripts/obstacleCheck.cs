using UnityEngine;

public class obstacleCheck : MonoBehaviour
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
}
