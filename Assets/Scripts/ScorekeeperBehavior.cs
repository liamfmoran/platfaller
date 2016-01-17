using UnityEngine;
using System.Collections;

public class ScorekeeperBehavior : MonoBehaviour {

    public static int Score1 = 0;
    public static int Score2 = 0;
    public static int Score3 = 0;
    public static int Score4 = 0;

    GameObject player1 = GameObject.Find("player1");
    GameObject player2 = GameObject.Find("player2");
    GameObject player3 = GameObject.Find("player3");
    GameObject player4 = GameObject.Find("player4");

    void Update()
    {
        Score1 = GameObject.Find("player1").GetComponent<PlayerController>().retrieveScore();
        print(Score1);
        Score2 = GameObject.Find("player2").GetComponent<PlayerController>().retrieveScore();
        Score3 = GameObject.Find("player3").GetComponent<PlayerController>().retrieveScore();
        Score4 = GameObject.Find("player4").GetComponent<PlayerController>().retrieveScore();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 150, 25), "Player 1 Score: " + Score1);
        /*if (GameObject.Find("player1") != null)
        {
            GUI.Label(new Rect(0, 0, 150, 25), "Player 1 Score: " + Score1);
        }
        if (GameObject.Find("player2") != null)
        {
            GUI.Label(new Rect(0, 25, 150, 25), "Player 2 Score: " + Score2);
        }
        if (GameObject.Find("player3") != null)
        {
            GUI.Label(new Rect(0, 50, 150, 25), "Player 3 Score: " + Score3);
        }
        if (GameObject.Find("player4") != null)
        {
            GUI.Label(new Rect(0, 75, 150, 25), "Player 4 Score: " + Score4);
        }*/
    }
}
