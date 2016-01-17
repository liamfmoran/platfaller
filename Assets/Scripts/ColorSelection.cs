using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ColorSelection : MonoBehaviour
{

	public Color[] colors;
	public List<Color> colorsLeft = new List<Color>();
	public Component[] tiles;
	public GameObject screen;

	float timeLeft = 5.0f;
    float restTime = 7.0f;

	void Start()
	{
		colors = new Color [4] {Color.blue, Color.gray, Color.white, Color.black};
		colorsLeft.Add(Color.blue);
		colorsLeft.Add(Color.gray);
		colorsLeft.Add(Color.white);
        colorsLeft.Add(Color.black);
		createTiles();
    }

    void Update()
    {
        if (GameObject.Find("GameController").GetComponent<GameController>().gameStart) {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = restTime;
                colorPicker();
            }
            if (timeLeft >= restTime - 0.35f && timeLeft <= restTime - 0.25f)
            {
                fall();
                if (GameObject.Find("player1").GetComponent<PlayerController>().checkAlive() == true)
                {
                    GameObject.Find("player1").GetComponent<PlayerController>().incrementScore();
                }
                if (GameObject.Find("player2").GetComponent<PlayerController>().checkAlive() == true)
                {
                    GameObject.Find("player2").GetComponent<PlayerController>().incrementScore();
                }
                if (GameObject.Find("player3").GetComponent<PlayerController>().checkAlive() == true)
                {
                    GameObject.Find("player3").GetComponent<PlayerController>().incrementScore();
                }
                if (GameObject.Find("player4").GetComponent<PlayerController>().checkAlive() == true)
                {
                    GameObject.Find("player4").GetComponent<PlayerController>().incrementScore();
                }
            }
            
        }
    }

	void colorPicker()
	{
		if (colorsLeft.Count != 0)
		{		
			Color cc = colorsLeft[(int)Random.Range(0, colorsLeft.Count)];
			colorsLeft.Remove(cc);
			screen = GameObject.Find("Color Selector");
			screen.GetComponent<Renderer>().material.color = cc;
		}		
	}

	void fall()
	{
		foreach(Transform tile in GameObject.Find("Floor").transform)
		{
			if (screen.GetComponent<Renderer>().material.color == tile.GetComponent<Renderer>().material.color)
			{			
				tile.GetComponent<Rigidbody>().isKinematic = false;
			}
		}
        
    }

	void createTiles()
	{
				
		foreach(Transform tile in GameObject.Find("Floor").transform)
		{
            Color randomColor = colors[(int) Random.Range(0, colors.Length)];
            tile.GetComponent<Renderer>().material.color = randomColor;
		}
	}
}
