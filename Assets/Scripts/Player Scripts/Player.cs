using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 8f;
	public float maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		PlayerMoveKeyboard ();
	}

	void PlayerMoveKeyboard () {
		float forceX = 0f;
		float velocity = Mathf.Abs (myBody.velocity.x);
		float horizontal = Input.GetAxisRaw ("Horizontal");

		if (horizontal > 0) {
			if (velocity < maxVelocity) {
				forceX = speed;
				anim.SetBool ("Walk", true);

				Vector3 temp = transform.localScale;
				temp.x = 1.3f;
				transform.localScale = temp;
			}
		} else if (horizontal < 0) {
			if (velocity < maxVelocity) {
				forceX = -speed;
				anim.SetBool ("Walk", true);

				Vector3 temp = transform.localScale;
				temp.x = -1.3f;
				transform.localScale = temp;
			}
		} else {
			anim.SetBool ("Walk", false);
		}

		myBody.AddForce (new Vector2(forceX, 0));
	}
}
