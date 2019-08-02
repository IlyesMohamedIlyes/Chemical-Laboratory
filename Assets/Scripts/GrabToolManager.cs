using UnityEngine;
using cakeslice;
using System.Collections.Generic;
using System;

public class GrabToolManager : MonoBehaviour
{
    public int _emplacementIndex = -1;
    public bool _doubleClicked = false;
    
	
	private float _lastClickTime = 0;
    private float _catchTime = 0.25f;

    private List<Outline> _selected = new List<Outline>();
    private Outline[] _allItems;

	public static GrabToolManager Instance {private set; get;}
	
    void Awake ()
	{
		Instance = this;
	}

    private void Start()
    {
        _allItems = GameObject.FindObjectsOfType<Outline>();
    }

    private void Update()
    {

        if (_emplacementIndex < 2)
        { 
            if (Input.GetMouseButtonDown(0) && !_doubleClicked)
            {
                if (Time.time - _lastClickTime < _catchTime)
                {
                    //IT's a double click

                    _doubleClicked = true;
                    
                    foreach (Outline sec in _allItems)

                        if (sec.GetComponent<Outline>().enabled)
                            _selected.Add(sec);


                    if (_selected.Count == 0)
                        return;


                    ShowHidePanelManager.Instance.ShowInventory();

                    if (_selected.Count == 1)
                    //
                    {
                        Debug.Log("Item is ONE");

                        var parent = _selected[0].gameObject.transform.parent.gameObject;
                        
                        // immobilise the item
                        var rig = parent.GetComponent<Rigidbody>();
                        if (rig != null)
                        {
                            rig.isKinematic = true;
                        }
                        
                        // Intantiate the parent
                        var obj = Instantiate(parent);

                       
                        //Put the item in the convenient place
                        _emplacementIndex++;
                        obj.transform.SetParent(ScreenShotReferenceManager.Instance._screenShotReference[_emplacementIndex].transform);
                        obj.transform.localPosition = Vector3.zero;

                        Destroy(obj.GetComponentInChildren<Outline>()); //To not use it another time!

                        parent.SetActive(false);  //We have just one item!

                        _selected[0].enabled = false; //to not select it when a second double-click occured

                    }
                    else
                    {
                        Debug.Log("More than one item selected!");
                    }

                    // fin

                    _doubleClicked = false;
                    _selected.Clear();
                }

                _lastClickTime = Time.time;
            }

        }
        else //Else of _EmplacementIndex is equal to 2
            Debug.Log("All emplacements are occupied cuz is : " + _emplacementIndex);
    }


}


