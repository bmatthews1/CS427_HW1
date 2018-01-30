using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (PlatformerCharacter2D))]
	public class WallJump : MonoBehaviour {
		public float distance = 1f;
		PlatformerCharacter2D movement;
		public float speed=2f;
		bool walljumping;

		Rigidbody2D rb;

		// Use this for initialization
		void Start () {
			movement = GetComponent<PlatformerCharacter2D> ();
			rb = GetComponent<Rigidbody2D>();
		}

		// Update is called once per frame
		void Update () {
			Physics2D.queriesStartInColliders = false;
			RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x,distance);

			if (CrossPlatformInputManager.GetButtonDown("Jump") && !movement.m_Grounded && hit.collider != null) 
			{
				//movement.Flip();
				movement.m_Grounded = true;
				//float h = CrossPlatformInputManager.GetAxis("Horizontal");
				//rb.AddForce(new Vector2(800,  movement.m_JumpForce));
				rb.AddForce(new Vector2(hit.normal.x*movement.m_JumpForce*2, movement.m_JumpForce*.7f));
				/*
				Vector2 vel = rb.velocity;
				vel.x += hit.normal.x*10;
				vel.y += movement.m_JumpForce/4;
				rb.velocity = vel;
				*/

				//GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed * hit.normal.x, speed);

			}
		}


		void OnDrawGizmos()
		{
			Gizmos.color = Color.red;

			Gizmos.DrawLine (transform.position, transform.position + Vector3.right * transform.localScale.x * distance);

		}
	}
}

