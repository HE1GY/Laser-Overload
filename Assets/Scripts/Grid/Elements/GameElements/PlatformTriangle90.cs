#region

using Grid.Elements;
using UnityEngine;
using UnityEngine.EventSystems;

#endregion

internal class PlatformTriangle90 : Element, IPointerDownHandler
{
    [SerializeField] private LaserThrower _LaserThrower;
    [SerializeField] private LaserThrower _LaserThrower2;
    public override ElementType ElementType { get; set; } = ElementType.PlatformTriangle90;
    public override IElementLogic ElementLogic { get; set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartRotation -= 90;
        _LaserThrower.ResetAll();
        _LaserThrower2.ResetAll();
    }
}