using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    public GameObject ballPrefab;
    GameObject attachedBall = null;
    // Use this for initialization
    void Start () {
        SpawnBall();
	}

   public void SpawnBall()
    {
        if (ballPrefab == null)
        {
            Debug.Log("Ball prefabnot linked in the inspector");
            return;
        }
        Vector3 ballPosition = transform.position + new Vector3(0,.5f,0);
        Quaternion ballRotation = Quaternion.identity;
        attachedBall = (GameObject)Instantiate(ballPrefab,ballPosition,ballRotation);
    }

    float paddleSpeed = 10f;
    // Update is called once per frame
    void Update() {
        transform.Translate(paddleSpeed*Time.deltaTime*Input.GetAxis("Horizontal"),0,0);
        
        if (attachedBall)
        {
            Rigidbody ballRigidboy = attachedBall.GetComponent<Rigidbody>();
            ballRigidboy.position = transform.position + new Vector3(0, .5f, 0);
            if (Input.GetButtonDown("Jump"))
            {

                ballRigidboy.isKinematic = false;
                ballRigidboy.AddForce(300f * Input.GetAxis("Horizontal"), 300f, 0);
                attachedBall = null;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        foreach (ContactPoint contact in col.contacts)
        {
            if (contact.thisCollider == GetComponent<Collider>())
            {
               float english = contact.point.x - transform.position.x;
                contact.otherCollider.GetComponent<Rigidbody>().AddForce(300f*english,0,0);
            }
        }
    }
}
