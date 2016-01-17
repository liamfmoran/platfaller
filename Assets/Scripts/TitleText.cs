using UnityEngine;
using System.Collections;

public class TitleText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find("GameController").GetComponent<GameController>().gameStart)
		{
			gameObject.SetActive(false);
		}
	
	}
}
