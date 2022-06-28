using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class DirectionSwitcherLogic : MonoBehaviour, IElementLogic,IPointerDownHandler
    {
        [SerializeField] private Element _directinSwitcher;
        public void OnPointerDown(PointerEventData eventData)
        {
            _directinSwitcher.StartRotation -= 90;
        }
    }
}