using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
    
    public float _distance = 3f;
    [Range (-7f, 7f)]
    public float _speed = 1f;
    public float _time = 3.5f;
    public Transform _liquidLevel;

	// Use this for initialization
	void Start () {

	    StartCoroutine ("Move");
	}
	
	// Update is called once per frame
	void Update () {

        var pos = transform.position;
        transform.position = new Vector3(pos.x, _liquidLevel.position.y, pos.z);

        transform.Translate(Vector3.right * _distance * Time.deltaTime * _speed);
    }

    

    IEnumerator Move ()
    {

		while (true) 
		{
			yield return new WaitForSeconds (_time);
            transform.eulerAngles += new Vector3(0, 100f, 0);
        }
				
	}

}
