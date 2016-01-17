using UnityEngine;
using System.Collections;

public class ScorekeeperBehavior : MonoBehaviour {

    public static int Score1;
    public static int Score2;
    public static int Score3;
    public static int Score4;

    void Awake()
    {
        Score1 = 0;
        Score2 = 0;
        Score3 = 0;
        Score4 = 0;
    }

    void OnGUI()
    {
        if (GameObject.Find("player1") != null)
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
        }
    }
}
