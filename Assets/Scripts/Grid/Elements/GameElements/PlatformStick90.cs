#region

using UnityEngine.EventSystems;

#endregion

namespace Grid.Elements
{
    public class PlatformStick90 : Element, IPointerDownHandler
    {
        public override ElementType ElementType { get; set; } = ElementType.PlatformStick90;
        public override IElementLogic ElementLogic { get; set; }


        public void OnPointerDown(PointerEventData eventData)
        {
            StartRotation -= 90;
        }
    }
}