#region

using Grid.Elements;
using UnityEngine;
using UnityEngine.EventSystems;

#endregion

public class LaserLogic : MonoBehaviour, IElementLogic, IPointerDownHandler
{
    [SerializeField] private Element _rotatableElement;
    [SerializeField] private LaserThrower[] _LaserThrowers;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnClick();
    }

    protected void OnClick()
    {
        _rotatableElement.StartRotation -= 90;
        foreach (var laserThrower in _LaserThrowers) laserThrower.ResetAll();
    }
}