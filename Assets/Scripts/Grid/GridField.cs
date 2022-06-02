using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridField : MonoBehaviour
{
    [SerializeField] private GridHolder[] _gridParts;
    private GridData _gridData;


    public GridData GetData()
    {
        _gridData.ExtractPartsData(_gridParts); 
        return _gridData;
    }

    public void SetData(GridData gridData)
    {
        
    }
}