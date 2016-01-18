using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public bool gameStart = false;
    public List<GameObject> players;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    Vector3 insert = new Vector3(0f, 2.2f, 0f);

    void Start()
    {
    }

    void Update()
    {
        if (!gameStart)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                Application.Quit();
            }
            if (Input.GetButtonDown("Submit"))
            {
                StartGame();
            }

            if (player1 == null && (Input.GetButtonDown("Jump_P1") || Input.GetKeyDown(KeyCode.Space)))
            {
                player1 = GameObject.Find("player1");
                players.Add(player1);
                GameObject.Find("player1").GetComponent<AudioSource>().Play();
                Debug.Log("Player 1 created");
            } else if (player2 == null && Input.GetButtonDown("Jump_P2"))
            {
                player2 = (GameObject)Instantiate(player1, insert, Quaternion.identity);
                player2.GetComponent<PlayerController>().horizontalControl = "Horizontal_P2";
                player2.GetComponent<PlayerController>().verticalControl = "Vertical_P2";
                player2.GetComponent<PlayerController>().jumpControl = "Jump_P2";
                player2.GetComponent<PlayerController>().powerControl = "Power_P2";
                player2.GetComponent<PlayerController>().playerColor = Color.yellow;
                players.Add(player2);
                GameObject.Find("player1").GetComponent<AudioSource>().Play();
                Debug.Log("Player 2 created");
            }

            if (player3 == null && Input.GetButtonDown("Jump_P3"))
            {
                player3 = (GameObject)Instantiate(player1, insert, Quaternion.identity);
                player3.GetComponent<PlayerController>().horizontalControl = "Horizontal_P3";
                player3.GetComponent<PlayerController>().verticalControl = "Vertical_P3";
                player3.GetComponent<PlayerController>().jumpControl = "Jump_P3";
                player3.GetComponent<PlayerController>().powerControl = "Power_P3";
                player3.GetComponent<PlayerController>().playerColor = Color.blue;
                players.Add(player3);
                GameObject.Find("player1").GetComponent<AudioSource>().Play();
                Debug.Log("Player 3 created");
            }

            if (player4 == null && Input.GetButtonDown("Jump_P4"))
            {
                player4 = (GameObject)Instantiate(player1, insert, Quaternion.identity);
                player4.GetComponent<PlayerController>().horizontalControl = "Horizontal_P4";
                player4.GetComponent<PlayerController>().verticalControl = "Vertical_P4";
                player4.GetComponent<PlayerController>().jumpControl = "Jump_P4";
                player4.GetComponent<PlayerController>().powerControl = "Power_P4";
                player4.GetComponent<PlayerController>().playerColor = Color.green;
                players.Add(player4);
                GameObject.Find("player1").GetComponent<AudioSource>().Play();
                Debug.Log("Player 4 created");
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Minigame");
        }
    }

    public void StartGame()
    {
        gameStart = true;
        if (player1 != null)
        {
            GameObject.Find("player1").GetComponent<AudioSource>().Play();
            player1.transform.position = new Vector3(1f, 2.2f, 1f);
        }

        if (player2 != null)
        {
            GameObject.Find("player1").GetComponent<AudioSource>().Play();
            player2.transform.position = new Vector3(-1f, 2.2f, 1f);
        }

        if (player3 != null)
        {
            GameObject.Find("player1").GetComponent<AudioSource>().Play();
            player3.transform.position = new Vector3(1f, 2.2f, -1f);
        }

        if (player4 != null)
        {
            GameObject.Find("player1").GetComponent<AudioSource>().Play();
            player4.transform.position = new Vector3(-1f, 2.2f, -1f);
        }
    }
}