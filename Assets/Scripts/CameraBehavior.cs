using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour
{

	public GameObject player1;
	public GameObject player2;
    public GameObject player3;
    public GameObject player4;

	public Vector3 middle;

	// Use this for initialization
	void SetCamPos() 
	{

        middle = (player1.transform.position * weight(player1.transform.position) + ((player2 != null) ? Vector3.zero : player2.transform.position * weight(player2.transform.position)) + ((player3 != null) ? Vector3.zero : player3.transform.position * weight(player3.transform.position)) + ((player4 != null) ? Vector3.zero : player4.transform.position * weight(player4.transform.position)) + new Vector3(0f, 0f, 0f)) / 4f;

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
