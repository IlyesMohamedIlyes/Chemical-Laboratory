using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotReferenceManager : MonoBehaviour
{
	
    public GameObject[] _screenShotReference;

	public static ScreenShotReferenceManager Instance {private set; get;}
	
	void Awake ()
	{
		Instance = this;
	}
	
    
}
