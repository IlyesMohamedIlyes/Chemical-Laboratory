using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDrag : MonoBehaviour {

    public float _distance = 10;

    void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = objectPos;
    }
}
