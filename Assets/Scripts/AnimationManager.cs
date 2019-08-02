using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class AnimationManager : MonoBehaviour {

	[SerializeField] private bool _isSitting = false;
					 
	private Animator _animator;

	void Start ()
	{
		_animator = GetComponent <Animator> ();
	}


	void FixedUpdate ()
	{
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis("Vertical");
		
		if (Input.GetKeyDown ("t")) 
		{
			_animator.SetBool ("IsSitting", !_isSitting);
			_isSitting = !_isSitting;
		}
		
		if (Input.GetKeyDown ("space"))
		{
			_animator.SetTrigger ("Jump");
		}
		
		if (horizontal != 0 || vertical != 0) 
			//Player on move
			_animator.SetBool ("IsWalking", true);
		
		else
			_animator.SetBool ("IsWalking", false);
			
		
	}
}
