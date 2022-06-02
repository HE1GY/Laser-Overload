using System;
using UnityEngine;

[Serializable]
public class GridHolder:MonoBehaviour
{
    [SerializeField] private ElementType _elementType;
    private int _startRoataion;
    
    public int SatartRotation => _startRoataion;
    public ElementType elementType => _elementType;
    
}