using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInformations : MonoBehaviour {

    private void Update()
    {
        Rigidbody rig = GetComponent<Rigidbody>();
        if (rig != null)
            rig.mass = TotalWeight / 1000;  // the mass of Rigidbody component is in Kg but the TotalWeight is in g.
    }

    [SerializeField] private string _name;
	public string Name 
	{
		get
		{ 
			return _name;
		}
	}

	[SerializeField] private float _width;
	public float Width
	{
		get
		{ 
			return _width;
		}
	}

	[SerializeField] private float _height;
	public float Height
	{
		get
		{ 
			return _height;
		}
	}

	[SerializeField] private float _volume; // in ml. -1 if not a container
	public float Volume
	{
		get
		{ 
			return _volume;
		}
	}

	[SerializeField] private float _weight; // in grammes
	public float Weight
	{
		get
		{ 
			return _weight;
		}
	}

	[SerializeField] private float _liquidVolume; // how much liquide does it contain
									// -1 if the tool is not to contain liquides
	public float LiquidVolume
	{
		get
		{ 
			return _liquidVolume;
		}
		set
		{ 
			_liquidVolume = value;
		}
	}


	public float TotalWeight
	{
		get
		{ 
			return _weight + _liquidVolume;
		}
	}

    [SerializeField] private double _lowest;

    public double Lowest
    {
        get
        {
            return _lowest;
        }
    }

    [SerializeField] private double _highest;

    public double Highest
    {
        get
        {
            return _highest;
        }
    }

}
