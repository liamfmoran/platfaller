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
    float powerUpTime = 0f;

    private bool firstRun = true;

    float powerUpFrequency = 5.0f;

	void Start()
	{
		colors = new Color [4] {Color.blue, Color.gray, Color.white, new Color(150,150,255)};
		colorsLeft.Add(Color.blue);
		colorsLeft.Add(Color.gray);
		colorsLeft.Add(Color.white);
        colorsLeft.Add(new Color(150, 150, 255));
	}

    void Update()
    {
        if (GameObject.Find("GameController").GetComponent<GameController>().gameStart) {
            if (firstRun)
            {
                createTiles();
                firstRun = false;
            }

            powerUpTime += Time.deltaTime;
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                timeLeft = restTime;
                colorPicker();
            }

            if (timeLeft >= restTime - 1.45f && timeLeft <= restTime - 1.35f)
            {
                fall();

                if (GameObject.Find("GameController").GetComponent<GameController>().player1.GetComponent<PlayerController>().checkAlive() == true)
                {
                    GameObject.Find("GameController").GetComponent<GameController>().player1.GetComponent<PlayerController>().incrementScore();
                }
                if (GameObject.Find("GameController").GetComponent<GameController>().player2.GetComponent<PlayerController>().checkAlive() == true)
                {
                    GameObject.Find("GameController").GetComponent<GameController>().player2.GetComponent<PlayerController>().incrementScore();
                }
                if (GameObject.Find("GameController").GetComponent<GameController>().player3.GetComponent<PlayerController>().checkAlive() == true)
                {
                    GameObject.Find("GameController").GetComponent<GameController>().player3.GetComponent<PlayerController>().incrementScore();
                }
                if (GameObject.Find("GameController").GetComponent<GameController>().player4.GetComponent<PlayerController>().checkAlive() == true)
                {
                    GameObject.Find("GameController").GetComponent<GameController>().player4.GetComponent<PlayerController>().incrementScore();
                }
        }

            if (powerUpTime >= powerUpFrequency + Random.Range(-1f, 1f))
            {
                List<GameObject> tiles = new List<GameObject>();

                foreach (Transform tile in GameObject.Find("Floor").transform)
                {
                    if (tile.GetComponent<Rigidbody>().isKinematic)
                    {
                        tiles.Add(tile.gameObject);
                    }
                }

                if (tiles.Count > 1)
                {
                    Instantiate(GameObject.Find("PowerUp").GetComponent<PowerUp>().gameObject, tiles[(int)Random.Range(0, tiles.Count)].transform.position + new Vector3(0, 0.5f), new Quaternion());
                }

                powerUpTime = 0f;
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
                tile.GetComponent<Rigidbody>().detectCollisions = false;
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
