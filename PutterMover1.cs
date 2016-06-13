using UnityEngine;
using System.Collections;
using System;



public class PutterMover : MonoBehaviour 
{
	public int force = 100;
	private Vector3 forceDirection = Vector3.forward;
	public Rigidbody rb;
	private bool keyPressed = false;

	void Awake ()

	{
	GameObject.Find ("Sphere").transform.localScale = new Vector3 (0, 0, 0);
	}

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		FirstFunction ();
	}
		
	void FirstFunction()
	{
		StartCoroutine (WaitforKeyPress ("Jump"));

	}
		
	public IEnumerator WaitforKeyPress(string button)
	{
		while (!keyPressed)
		{
			if (Input.GetButtonDown (button)) 
			{
				Debug.Log ("button pressed");
				GameObject.Find ("Sphere").transform.localScale = new Vector3 (1, 1, 1);
				GameObject.Find ("Sphere").transform.position = new Vector3 (0.0f, 0.5f, 0.0f);
				FixedUpdate ();
				break;

			}
			Debug.Log ( "Awaiting Input");
			GameObject.Find ("Sphere").transform.localScale = new Vector3 (0, 0, 0);
			yield return 0;
		}
	}


	void FixedUpdate()
	{

		if (Input.GetButton("Jump"))
		{

			if (transform.position.z < 0.5f) 
			{
				transform.position = new Vector3 (transform.position.x, transform.position.y, 0.5f);
				rb.AddForce (forceDirection * 0);
			} 

			else if (transform.position.z >= 18.5f) 
				
			{
				transform.position = new Vector3 (transform.position.x, transform.position.y, 18.5f);
				rb.AddForce (-forceDirection * force);
			} 

			else 
			{
				rb.AddForce (forceDirection * 20);
			}
		}

		else if(!Input.GetButton("Jump"))
		{
			
			if (transform.position.z > 18.5f) 
			{
				transform.position = new Vector3 (transform.position.x, transform.position.y, 18.5f);
				rb.AddForce (forceDirection * 0);

			}
			else if (transform.position.z <= 0.5f) 
			{
				transform.position = new Vector3 (transform.position.x, transform.position.y, 0.5f);
				rb.AddForce (forceDirection * 0);
			}
			else 
			{
				rb.AddForce (-forceDirection * force);

			}
		}
		else
		{
			Debug.Log ("You Lost the game");
		}


	}
}