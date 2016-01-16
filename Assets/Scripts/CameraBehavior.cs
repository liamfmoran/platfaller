using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour
{

	public GameObject player1;
	public GameObject player2;

	public Vector3 middle;

	// Use this for initialization
	void SetCamPos() 
	{
	
		middle = (player1.transform.position + player2.transform.position)* 0.5f;

		transform.position = new Vector3(
			middle.x,
			transform.position.y,
			transform.position.z
		);
		
	
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		SetCamPos();
	}
}
