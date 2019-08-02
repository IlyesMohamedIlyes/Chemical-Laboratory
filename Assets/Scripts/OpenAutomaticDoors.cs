using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAutomaticDoors : MonoBehaviour 
{

	private Animator _animator;

	void Start ()
	{
		_animator = GetComponent <Animator> ();
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player") 
		{
			Debug.Log ("PLayer Enter");

			_animator.SetTrigger ("Open");
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Player") 
		{
			Debug.Log ("PLayer Exit");
			_animator.SetTrigger ("Close");
		}
	}
		
}
