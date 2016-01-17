using UnityEngine;
using System.Collections;

public class WallToggle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (GameObject.Find("GameController").GetComponent<GameController>().gameStart == true)
		{
			GetComponent<Renderer>().enabled = true;
			GetComponent<Collider>().enabled = true;
		}
		else
		{
			GetComponent<Renderer>().enabled = false;
			GetComponent<Collider>().enabled = false;
		}
	}
}
