using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (Rigidbody))]

public class FloatingObject : MonoBehaviour {


    public Transform _waterLevel;
    public float _height = 2f;
    public float _bounceDump = 0.01f;
    public Vector3 _CenterOffSet;

    private float _forceFactor;
    private Vector3 _actionPoint;
    private Vector3 _upLift;
    private Rigidbody _rig;

    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update ()
    {

        var y = _waterLevel.position.y;

        Debug.Log("Water level is : " + y + " and the object is " + transform.position.y);

        _actionPoint = transform.position + transform.TransformDirection(_CenterOffSet);
        _forceFactor = 1f - ((_actionPoint.y - y) / _height);

        if (_forceFactor > 0f)

        {
            _upLift = -Physics.gravity * (_forceFactor - _rig.velocity.y * _bounceDump);
            _rig.AddForceAtPosition(_upLift, _actionPoint);
        }
    }
}
