using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		Animator m_Anim;

		Rigidbody2D rb;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
			m_Anim = GetComponent<Animator>();
			rb = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }

		void OnCollisionEnter2D (Collision2D collision)
		{
			if (collision.gameObject.tag == "Enemy" && !collision.gameObject.GetComponent<EnemyWalk>().death){
				foreach (ContactPoint2D contact in collision.contacts){
					float a = Mathf.Abs(Vector3.Angle(contact.normal, Vector3.up));
					if (a > 60) m_Character.die();
				}

				if (!m_Character.death) rb.AddForce(Vector3.up*m_Character.m_JumpForce/2f);
			}

			if (collision.gameObject.tag == "Finish"){
				m_Character.finish();
				print("you won!");
			}
		}
    }
}
