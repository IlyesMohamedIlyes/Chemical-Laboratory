using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (ToolInformations))]
public class LiquidAmountManager : MonoBehaviour
{

    private ToolInformations _infos;

    public GameObject _LiquidAmount;
    

    private void Awake()
    {
        _infos = GetComponent<ToolInformations>();
    }

    void Start()
    {

        if (_infos != null) 
            _infos.LiquidVolume = (float)(_LiquidAmount.transform.localPosition.z * _infos.Volume / _infos.Highest);
    }


    void UpdateLiquidAmount (double weight)
    {
        if (_LiquidAmount.transform.localPosition.z < _infos.Highest)
        {
            //   var val = (float)((_infos.Highest - _LiquidAmount.transform.localPosition.z)) / 100;

            var val = (float)(weight * _infos.Highest / _infos.Volume);

            _LiquidAmount.transform.localPosition += Vector3.forward * val;

            _infos.LiquidVolume = (float)(_LiquidAmount.transform.localPosition.z * _infos.Volume / _infos.Highest);
        }
    }
}
