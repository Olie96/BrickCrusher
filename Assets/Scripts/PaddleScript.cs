using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Horizontal") < 0)
        { 
            Debug.Log("Left");
           transform.Translate(-8f*Time.deltaTime, 0, 0);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            Debug.Log("Right");
            transform.Translate(8f * Time.deltaTime, 0, 0);
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
