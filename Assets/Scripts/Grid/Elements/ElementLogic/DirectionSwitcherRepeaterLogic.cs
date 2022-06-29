#region

using UnityEngine.EventSystems;

#endregion

namespace Grid
{
    public class DirectionSwitcherRepeaterLogic : DirectionSwitcherLogic, IRepeater
    {
        private void OnEnable()
        {
            IRepeater.Turned += OnClick;
        }


        private void OnDisable()
        {
            IRepeater.Turned -= OnClick;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            IRepeater.Turn();
        }
    }
}