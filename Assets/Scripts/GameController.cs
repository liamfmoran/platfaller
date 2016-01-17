using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    bool playerOne;

    Vector3 insert = new Vector3(0,10,0);

    // Use this for initialization
    void Start () {
        playerOne = false;
        player1 = GameObject.Find("player1");
    }

    void Update ()
    {
        if (!playerOne && Input.GetKeyDown(KeyCode.Space))
        {
            playerOne = true;
        }
        else if (player2 == null && Input.GetButtonDown("Jump_P2"))
        {
            playerOne = true;
            player2 = (GameObject)Instantiate(player1,insert, Quaternion.identity);
            player2.GetComponent<PlayerController>().horizontalControl = "Horizontal_P2";
            player2.GetComponent<PlayerController>().verticalControl = "Vertical_P2";
            player2.GetComponent<PlayerController>().jumpControl = "Jump_P2";
        }

        if (player3 == null && Input.GetButtonDown("Jump_P3"))
        {
            player3 = (GameObject)Instantiate(player1,insert, Quaternion.identity);
            player3.GetComponent<PlayerController>().horizontalControl = "Horizontal_P3";
            player3.GetComponent<PlayerController>().verticalControl = "Vertical_P3";
            player3.GetComponent<PlayerController>().jumpControl = "Jump_P3";
        }

        if (player4 == null && Input.GetButtonDown("Jump_P4"))
        {
            player4 = (GameObject)Instantiate(player1,insert, Quaternion.identity);
            player4.GetComponent<PlayerController>().horizontalControl = "Horizontal_P4";
            player4.GetComponent<PlayerController>().verticalControl = "Vertical_P4";
            player4.GetComponent<PlayerController>().jumpControl = "Jump_P4";
        }
    }
}
