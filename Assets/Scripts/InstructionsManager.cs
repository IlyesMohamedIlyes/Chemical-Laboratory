using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour {

    public GameObject _confirmationPanel;
    public GameObject _InformationsPanel;
    public GameObject _RemovalPanel;

    public static InstructionsManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }




}
