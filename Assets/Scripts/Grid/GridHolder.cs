using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class GridHolder:MonoBehaviour
{
    [SerializeField] private ElementType _selectedElementType;
    [SerializeField] private Element[] _elements;

    private Element _currentElement;
    public ElementType SelectedElementType
    {
        get => _selectedElementType;
        set
        {
            _selectedElementType = value;
            OnElementTypeChange();
        }
    }

    public int StartRotation
    {
        get => GetTrackedRotate();
        set
        {
            if (_currentElement)
            {
                _currentElement.transform.rotation = Quaternion.Euler(0, 0, value);
            }
        }
    }


    private void OnValidate()
    {
        OnElementTypeChange();
    }

    private int GetTrackedRotate()
    {
        if (_currentElement)
        {
            return (int)_currentElement.transform.rotation.eulerAngles.z;
        }
        return 0;
    }
    private void OnElementTypeChange()
    {
        if (_selectedElementType != _currentElement?.ElementType)
        {
            _currentElement?.Deactivate();
            foreach (Element element in _elements)
            {
                if (element.ElementType == _selectedElementType)
                {
                    _currentElement = element;
                    element.Activate();
                }
                else if (_selectedElementType==ElementType.Empty)
                {
                    _currentElement = null;
                }
            }
        }
    }
}