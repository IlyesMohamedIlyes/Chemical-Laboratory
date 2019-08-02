using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactElements : MonoBehaviour
{

    public List<GameObject> _elements;
    public List<GameObject> _reactionsInProcess;


    public bool AddElement (ElementInformations element)
    {


        return true;
    }

    public bool RemoveElement (ElementInformations element)
    {


        return true;
    }


    private void Awake()
    {
        if (_elements == null)
            _elements = new List<GameObject> ();

        if (_reactionsInProcess == null)
            _reactionsInProcess = new List<GameObject> ();
    }
}
