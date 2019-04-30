using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody rgb;
    public float moveSpeed = 14;
    
	// Use this for initialization
	void Start ()
    {
        rgb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {        
        rgb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rgb.velocity.y, Input.GetAxis("Vertical") *moveSpeed);
    }
}
