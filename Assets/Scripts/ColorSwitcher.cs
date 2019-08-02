using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{

    public bool _switch = false;

    public Color _colorActuel;
    public Color _colorTarget;
    [Range (0.1f, 5)]
    public float _changingSpeed = 1f;

    private Material _materialComponent;

    private void Awake()
    {
        _materialComponent = GetComponent<MeshRenderer>().material;
    }

	
	// Update is called once per frame
	void Update ()
    {
        if (_switch)
        {
            _materialComponent.SetColor ("_CrossColor", Color.Lerp (_colorActuel, _colorTarget, Time.deltaTime * _changingSpeed));
        }

        if (Input.GetKeyDown("h"))
            _switch = !_switch;


        _colorActuel = _materialComponent.GetColor("_CrossColor");
    }
}
