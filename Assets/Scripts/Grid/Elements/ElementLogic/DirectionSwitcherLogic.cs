using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class DirectionSwitcherLogic : MonoBehaviour, IPointerDownHandler, IElementLogic
    {
        [SerializeField] private Element _directinSwitcher;
        
        protected void OnClick()
        {
            _directinSwitcher.StartRotation -= 90;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnClick();
        }
    }
}