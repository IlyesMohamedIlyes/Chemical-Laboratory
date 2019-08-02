using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosetsDoors : MonoBehaviour {

	public bool _leftSide = false;

	private Animator _animator;

    List<GameObject> _closetDoors = new List<GameObject>();

	void Start ()
	{
		_animator = GetComponent <Animator> ();
		_animator.SetBool ("LeftSide", _leftSide);
	}


	void FixedUpdate () {

		if (Input.GetKeyDown ("k"))
			_animator.SetBool ("IsOpen", true);
		

		if (Input.GetKeyDown ("l"))
			_animator.SetBool ("IsOpen", false);
		
	}
}
