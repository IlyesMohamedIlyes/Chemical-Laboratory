using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidRotation : MonoBehaviour {

    public GameObject _liquid;

    public int _sloshSpeed = 60;
  //  private int _rotateSpeed = 15;

    private int _difference = 25;

	
	// Update is called once per frame
	void Update ()
    {

        Sloch ();

	}

    private void Sloch()
    {
        var realRotation = new Quaternion(transform.localRotation.x - 0.3f, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w - 0.7f);

        Quaternion inverseRotation = Quaternion.Inverse(realRotation);

        Vector3 finalRotation = Quaternion.RotateTowards (_liquid.transform.localRotation, inverseRotation, _sloshSpeed * Time.deltaTime).eulerAngles;
         
        finalRotation.x = ClampRotationValue (finalRotation.x, _difference);
        finalRotation.z = ClampRotationValue (finalRotation.z, _difference);

        _liquid.transform.localEulerAngles = finalRotation;
    }

    private float ClampRotationValue(float value, float difference)
    {
        float returnValue = 0.0f;

        if (value > 100)
            returnValue = Mathf.Clamp(value, 360 - difference, 360);

        else
            returnValue = Mathf.Clamp(value, 0, 360);


        return returnValue;
    }
}
