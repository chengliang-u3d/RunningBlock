using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Vector2 jumpDirection;
    float jumpSpeed = 5;

    Rigidbody rb;

    public Vector3 curVec;

	// Use this for initialization
	void Start () {
        jumpDirection = new Vector2(1f, 1f);
        //jumpDirection = jumpDirection.normalized;

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }

        curVec = rb.velocity;
    }

    void Jump()
    {
        rb.velocity = jumpDirection * jumpSpeed;
        curVec = rb.velocity;
    }
}
