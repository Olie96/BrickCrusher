using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // GetComponent<Rigidbody>().AddForce(0,600f,0);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Die()
    {
        Destroy(gameObject);
        GameObject paddleObject = GameObject.Find("Paddle");
        PaddleScript paddleScript = paddleObject.GetComponent<PaddleScript>();
        paddleScript.SpawnBall();
    }

}
