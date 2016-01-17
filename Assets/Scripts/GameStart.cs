using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionExit(Collision collision)
    	{
    		if (collision.gameObject.CompareTag("Player"))
       		{
			GameObject.Find("GameController").GetComponent<GameController>().StartGame();
			print("Here");

			//StartGame();
        	}
    	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
