using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ballMovement : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float horizontalSpeed = 0.05f;
    public float xLimit = 0.8f;
    public float boostSpeed = 2f;
    public float speedIncrement = 2f;
    public float interval = 3f;
    private Rigidbody rb;
    private float time = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardMove = transform.forward * forwardSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Sağ/Sol tıklama kontrolü
        float currentX = rb.position.x;
        float targetX = currentX;

        if (Input.GetMouseButtonDown(0)) // Sol click
        {
            targetX = currentX - horizontalSpeed;
        }
        else if (Input.GetMouseButtonDown(1)) // Sağ click
        {
            targetX = currentX + horizontalSpeed;
        }

        // Sınırla
        targetX = Mathf.Clamp(targetX, -xLimit, xLimit);

        rb.MovePosition(new Vector3(targetX, rb.position.y, rb.position.z));

        if (Keyboard.current.spaceKey.isPressed)  // Mouse için
        {
            rb.MovePosition(rb.position + transform.forward * forwardSpeed * Time.fixedDeltaTime * 2); // boost
        }

        time += Time.fixedDeltaTime;

        if (forwardSpeed <= 0.6)
        {
            if (time >= interval)
            {
                forwardSpeed = speedIncrement * forwardSpeed;
                time = 0f;

            }
        }

        else if (forwardSpeed >= 0.6)
        {

            return;

        }

    }

    /*
    if (Touchscreen.current.primaryTouch.press.isPressed)
    {
        rb.MovePosition(rb.position + transform.forward * forwardSpeed * Time.fixedDeltaTime * 2); // boost
    }*/

}

