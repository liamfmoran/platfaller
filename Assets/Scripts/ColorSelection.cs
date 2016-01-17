using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ColorSelection : MonoBehaviour
{	

	public Color[] colors;
	public List<Color> colorsLeft = new List<Color>();
	public Component[] tiles;
	public GameObject screen;
	//public Rigidbody rb;
	float timeLeft = 5.0f;

	void Start()
	{
		colors = new Color [3] {Color.blue, Color.gray, Color.white};
		colorsLeft.Add(Color.blue);
		colorsLeft.Add(Color.gray);
		colorsLeft.Add(Color.white);
		createTiles();
	}

	void Update()
	{

         	timeLeft -= Time.deltaTime;
         	if(timeLeft < 0)
         	{
			timeLeft = 15.0f;
            		colorPicker();
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

		fall();
		
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
				Color randomColor = colors[(int)Random.Range(0, colors.Length)];
				tile.GetComponent<Renderer>().material.color = randomColor;
		}
	}
}
