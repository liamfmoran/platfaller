
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;

    public bool jumpValue = true;
    public float speed;
    public float jumpForce;

    public string horizontalControl = "Horizontal_P1";
    public string verticalControl = "Vertical_P1";
    public string jumpControl = "Jump_P1";


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpValue = true;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(horizontalControl);
        float moveVertical = Input.GetAxis(verticalControl) * -1;

        if (Input.GetButtonDown(jumpControl) && jumpValue == true)
        {
            movement = new Vector3(moveHorizontal, jumpForce, moveVertical);
            jumpValue = false;
        }
        else
        {
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        }

        rb.AddForce(movement * speed);
    }
}
