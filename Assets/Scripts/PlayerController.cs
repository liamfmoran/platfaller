
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;

    public bool canJump = true;
    public float speed;
    public float jumpForce;
    public bool alive;

    public string horizontalControl = "Horizontal_P1";
    public string verticalControl = "Vertical_P1";
    public string jumpControl = "Jump_P1";

    public AudioClip ac;


    void Start()
    {
        alive = true;
        rb = GetComponent<Rigidbody>();

    }

	
    void PlaySound(int clip)
    {
	GetComponent<AudioSource>().clip = ac;
	//GetComponent<AudioSource>().Play();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && gameObject.transform.position.y > 0)
        {
            canJump = true;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(horizontalControl);
        float moveVertical = Input.GetAxis(verticalControl) * -1;

        if (!canJump)
        {
            speed = 12;
        }
        else
        {
            speed = 20;
        }

        if (Input.GetButtonDown(jumpControl) && canJump)
        {
            movement = new Vector3(moveHorizontal, jumpForce, moveVertical);
            canJump = false;
        }
        else
        {
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        }

        rb.AddForce(movement * speed);
    }
}
