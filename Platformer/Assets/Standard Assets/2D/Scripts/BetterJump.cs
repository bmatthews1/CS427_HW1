using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//from 

public class BetterJump : MonoBehaviour {

	public float fallMult = 2.5f;
	public float lowMult = 2f;

	Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.y < 0) rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1f) * Time.deltaTime;
		if (rb.velocity.y > 0 && !CrossPlatformInputManager.GetButton("Jump")) 
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMult - 1f) * Time.deltaTime;
	}
}
