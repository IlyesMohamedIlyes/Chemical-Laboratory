using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElementInformations : MonoBehaviour
{
    [SerializeField]
    private string _code;
    public string Code
    {
        get
        {
            return _code;
        }
    }

    [SerializeField]
    private string _fullName;
    public string FullName
    {
        get
        {
            return _fullName;
        }
    }

    [SerializeField]
    private int _ANumber;
    public int ANumber
    {
        get
        {
            return _ANumber;
        }
    }

    [SerializeField]
    private string _atomicMass;
    public string AtomicMass
    {
        get
        {
            return _atomicMass;
        }
    }

    [SerializeField]
    private string _state; // "Liquid", "Solid", "Gas"
    public string State
    {
        get
        {
            return _state;
        }
    }

    [SerializeField]
    private double _weight;
    public double Weight
    {
        get
        {
            return _weight; // in gramms
        }
    }
    
    [SerializeField]
    private Material _primaryColor;
    public Material PrimaryColor
    {
        get
        {
            return _primaryColor;
        }
    }
    
    [SerializeField]
    private List<Material> _reactionColors;
    public List<Material> ReactionColors
    {
        get
        {
            return _reactionColors;
        }
    }

    private bool _alreadyInUse = false;
    public bool InUse
    {
        get
        {
            return _alreadyInUse;
        }
        set
        {
            _alreadyInUse = value;
        }
    }

    private double _timer = 0.0;
    public double Timer
    {
        get
        {
            return _timer;
        }

        set
        {
            _timer = value;
        }
    }

}
