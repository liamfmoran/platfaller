
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;

    public bool canJump = true;
    public float speed;
    public float jumpForce;
    public bool alive;

    public int powerCode;

    public Color playerColor = Color.red;

    public string horizontalControl = "Horizontal_P1";
    public string verticalControl = "Vertical_P1";
    public string jumpControl = "Jump_P1";
    public string powerControl = "Power_P1";

    public AudioClip ac;

    void Start()
    {
        alive = true;
        rb = GetComponent<Rigidbody>();

        powerCode = 0;
    }

    void PlaySound(int clip)
    {
        GetComponent<AudioSource>().clip = ac;
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

        if (Input.GetButtonDown(powerControl) && powerCode == 1)
        {
            PowerForcePush();
        }

        switch (powerCode)
        {
            case 1:
                gameObject.GetComponent<Renderer>().material.color = new Color(200,200,255);
                break;
        }

        rb.AddForce(movement * speed);
    }

    void PowerForcePush()
    {
        Vector3 position = gameObject.transform.position;
        List<GameObject> players = GameObject.Find("GameController").GetComponent<GameController>().players;
        foreach (GameObject player in players)
        {
            if (player != gameObject)
            {
                Vector3 forceVector = (player.transform.position - position).normalized;
                Rigidbody rigidBody = player.GetComponent<Rigidbody>();
                float distance = Vector3.Distance(position, player.transform.position);
                if (distance < 8f) {
                    rigidBody.AddForce(forceVector * 40 * (8f - distance));
                }
            }
        }
        gameObject.GetComponent<Renderer>().material.color = playerColor;
        powerCode = 0;
    }
}
