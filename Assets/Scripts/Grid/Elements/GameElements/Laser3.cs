#region

using UnityEngine.EventSystems;

#endregion

namespace Grid
{
    public class Laser3 : Element, IPointerDownHandler
    {
        public override ElementType ElementType { get; set; } = ElementType.Laser3;
        public override IElementLogic ElementLogic { get; set; }


        public void OnPointerDown(PointerEventData eventData)
        {
            StartRotation -= 90;
        }
    }
}