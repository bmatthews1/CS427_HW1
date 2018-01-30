using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour {

	public float walkSpeed = .1f;
	public bool death = false;
	Animator m_Anim;

	private float elapsedDeath = 0;
	public float deathWait = .5f;

	public float lookDist = .25f;

	private Vector2 look1 = new Vector2(-1, -1);
	private Vector2 look2 = new Vector2(1, -1);

	// Use this for initialization
	void Start () {
		m_Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (death){
			elapsedDeath += Time.deltaTime;
			if (elapsedDeath > deathWait) Destroy(gameObject);

			return;
		}

		if (!Physics2D.Raycast(transform.position, look1, transform.localScale.x*lookDist)) walkSpeed *= -1;
		if (!Physics2D.Raycast(transform.position, look2, transform.localScale.x*lookDist)) walkSpeed *= -1;


		Vector3 pos = transform.position;
		pos.x += walkSpeed;
		transform.position = pos;
	}

	void die(){
		death = true;
		m_Anim.SetBool("death", true);
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Player"){
			foreach (ContactPoint2D contact in collision.contacts){
				float a = Vector3.Angle(contact.normal, Vector3.up);
				if (a > 120) die();
			}
		}
		walkSpeed *= -1;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, transform.position + new Vector3(-1, -1, 0) * transform.localScale.x * lookDist);
		Gizmos.DrawLine (transform.position, transform.position + new Vector3(1, -1, 0) * transform.localScale.x * lookDist);

	}
}
