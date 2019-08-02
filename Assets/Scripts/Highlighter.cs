using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;


public class Highlighter : MonoBehaviour {

	
    public void OnTriggerEnter(Collider other)
    {
        var comp = other.GetComponent<Outline>();

        if (comp == null)
            Debug.Log(other.name + " don't have Outline component.");
        else
            comp.enabled = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            return;

        var comp = other.GetComponent<Outline>();

        if (comp == null)
            Debug.Log(other.name + " don't have Outline component.");
        else
            comp.enabled = false;
    }

}
