
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    public bool jumpValue = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision Collision)
    {
        jumpValue = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement;
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpValue == true)
        {
            movement = new Vector3(moveHorizontal, 10.0f, moveVertical);
            jumpValue = false;
        }
        else
        {
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        }
        rb.AddForce(movement * speed);
    }
}
