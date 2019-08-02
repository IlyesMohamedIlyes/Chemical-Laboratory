using System;
using UnityEngine;
using UnityEngine.UI;

public class SpriteController : MonoBehaviour {

    private GameObject _target;
    private int _spriteInControl = -1; //number of places took
    private Vector3[] _origins = new Vector3[2];


    private void Start()
    {
        _origins[0] = new Vector3(55, 0, 0);
        _origins[1] = new Vector3(-55, 0, 0);
    }

    public void InitializeTarget(GameObject target)
    {
        _target = target;
		int.TryParse(_target.name.Substring (_target.name.Length-1, 1), out _spriteInControl);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_spriteInControl == -1)
            return;
		
        if (_target == null)
            return;
        

        if (Input.GetMouseButtonDown(1))
        {
            _target = null;
            return;
        }
        //Verify holding mouse button
        if (Input.GetMouseButton(0))
        {
            _target.transform.position = Input.mousePosition;

            _target.transform.SetAsLastSibling();
        }
        else
            BackToOrigin();

		ToggleOverload ();
    }

	
    private void BackToOrigin ()
    {
        try
        {
            _target.GetComponent<RectTransform>().localPosition = _origins[_spriteInControl - 1];
        }
        catch (Exception)
        {
            //Another way to do the work just in case _place is outbounded
            if (_target.name.EndsWith("1"))
                _target.GetComponent<RectTransform>().localPosition = new Vector3(55, 0, 0);

            else
                _target.GetComponent<RectTransform>().localPosition = new Vector3(-55, 0, 0);
        }
    }

    private void ToggleOverload()
    {
		//Never enter if not all emplacements occupied. Can be modified if more than 2 emplacements
		if (GrabToolManager.Instance._emplacementIndex < 1) // this can be 0 or 1
			return;

        var targetPosition = new Vector2(_target.transform.localPosition.x, _target.transform.localPosition.y);
        		
		var enable_1 = targetPosition.x < -25 && targetPosition.x > -75 && targetPosition.y > -95 && targetPosition.y < 95;
		var enable_2 = targetPosition.x > 25 && targetPosition.x < 75 && targetPosition.y > -95 && targetPosition.y < 95;
		
		if (_spriteInControl == 1)
		{
			var overredSprite = GameObject.Find ("Emplacement_"+2).GetComponentInChildren<Image>();

			if (overredSprite == null)
				return;
			
			if (overredSprite.enabled == enable_1)
				return;

			overredSprite.enabled = enable_1;
		}
		else
		{
			var overredSprite = GameObject.Find ("Emplacement_"+1).GetComponentInChildren<Image>();

			if (overredSprite == null)
				return;
			
			if (overredSprite.enabled == enable_2)
				return;

			overredSprite.enabled = enable_2;
		
		}	
		
        // This will happen only if a sprite is on another
		if (Input.GetMouseButtonUp (0))
		{
			_target = null;
			InstructionsManager.Instance._confirmationPanel.SetActive (true);
		}
    }

   
    
}
