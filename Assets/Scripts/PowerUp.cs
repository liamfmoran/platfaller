using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour {

    public float speed = 10f;
    float time = 0f;

    float lifeTime = 0;
    float deathTime = 2;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        lifeTime += Time.deltaTime;

        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        transform.Translate(Mathf.Sin(time * 3) * Vector3.up * 0.01f);

        if (lifeTime > deathTime && transform.position.y < 5)
        {
            Destroy(gameObject);
            deathTime = 0;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.GetComponent<PlayerController>().powerCode = 1;
            Destroy(gameObject);
        }
    }
}
