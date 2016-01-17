using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraBehavior : MonoBehaviour
{

    List<GameObject> players;

	public Vector3 middle;

	// Use this for initialization
	void SetCamPos() 
	{
        players = GameObject.Find("GameController").GetComponent<GameController>().players;
        middle = Vector3.zero;
        foreach(GameObject player in players)
        {
            middle += player.transform.position * weight(player.transform.position);
        }

        middle /= players.Count + 1;

		transform.position = new Vector3(
			middle.x,
			transform.position.y,
			transform.position.z
		);
		
	
	}

    float weight (Vector3 a)
    {
        float distance = Vector3.Distance(new Vector3(0f, 0f, 0f), a);
        if (distance < 100f)
        {
            return (100f - Vector3.Distance(new Vector3(0f, 0f, 0f), a)) / 100f;
        }
        else return 0f;
    }
	
	// Update is called once per frame
	void LateUpdate ()
	{
		SetCamPos();
	}
}
