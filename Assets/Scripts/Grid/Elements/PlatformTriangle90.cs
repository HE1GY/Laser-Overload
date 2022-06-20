#region

using Grid.Elements;
using UnityEngine;
using UnityEngine.EventSystems;

#endregion

internal class PlatformTriangle90 : Element
{
    [SerializeField] private LaserThrower _LaserThrower;
    [SerializeField] private LaserThrower _LaserThrower2;
    public override ElementType ElementType { get; set; } = ElementType.PlatformTriangle90;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        _LaserThrower.ResetAll();
        _LaserThrower2.ResetAll();
    }
}