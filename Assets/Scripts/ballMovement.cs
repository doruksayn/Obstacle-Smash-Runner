using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ballMovement : MonoBehaviour
{
    public float forwardSpeed;
    public float horizontalSpeed;
    public float xLimit;
    public float speedIncrement;
    public float interval;
    private Rigidbody rb;
    private float time = 0f;
    private float targetX;

    // Swipe kontrol için
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetX = rb.position.x;
        rb.linearVelocity = new Vector3(0f, rb.linearVelocity.z, forwardSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Z ekseninde düz hareket etmesini sağlar.
        rb.linearVelocity = new Vector3(0f, 0f, forwardSpeed);
        // Vector3 forwardMove = transform.forward * forwardSpeed * Time.fixedDeltaTime;

        // Top fiziğe uygun şekilde dönerek hızlanır.

        // Sağ/Sol tıklama kontrolü
        // float currentX = rb.position.x;
        // float targetX = currentX;

        if (Input.GetMouseButtonDown(0)) // Sol click
        {
            targetX -= horizontalSpeed;
        }
        else if (Input.GetMouseButtonDown(1)) // Sağ click
        {
            targetX += horizontalSpeed;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                startTouchPos = touch.position;
            }
            else if (touch.phase == UnityEngine.TouchPhase.Ended)
            {
                endTouchPos = touch.position;
                float deltaX = endTouchPos.x - startTouchPos.x;

                if (deltaX > 0)
                {
                    // Sağa kaydırma
                    targetX += horizontalSpeed;
                }
                else if (deltaX < 0)
                {
                    // Sola kaydırma
                    targetX -= horizontalSpeed;
                }
            }
        }

        // X eksenini sınırlama
        targetX = Mathf.Clamp(targetX, -xLimit, xLimit);

        rb.MovePosition(new Vector3(targetX, rb.position.y, rb.position.z));

        // forwadSpeed sınırlama
        time += Time.fixedDeltaTime;

        if (forwardSpeed <= 1)
        {
            if (time >= interval)
            {
                forwardSpeed = speedIncrement * forwardSpeed;
                time = 0f;
            }
        }
        else if (forwardSpeed >= 1)
        {
            return;
        }
    }
}
