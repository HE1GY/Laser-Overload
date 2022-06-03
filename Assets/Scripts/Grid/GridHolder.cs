using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class GridHolder:MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private Element[] _elements;
    [SerializeField] private ElementType _selectedElementType;

    private Element _currentElement;
    private ElementType _currentElementType;
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
        if (_currentElementType != _selectedElementType)
        {
            if (_currentElement)
            {
                _currentElement.Deactivate();
            }
            foreach (var element in _elements)
            {
                if (element.ElementType == _selectedElementType)
                {
                    _currentElementType = _selectedElementType;
                    _currentElement = element;
                    _currentElement.Activate();
                    return;
                }
            }
            _currentElement = null;
            _currentElementType = ElementType.Empty;
            _selectedElementType = ElementType.Empty;
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            Selection.activeObject = gameObject;
        }
        else
        {
            SelectedElementType = ElementType.Empty;
        }
    }
}