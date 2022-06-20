#region

using Grid.Elements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#endregion

namespace Grid
{
    public class Star : Element
    {
        [SerializeField] private LaserReceiver[] _laserReceiver;

        [SerializeField] private Image _image;
        private int Energy;
        public override ElementType ElementType { get; set; } = ElementType.Star;


        private void OnEnable()
        {
            foreach (var laserReceiver in _laserReceiver) laserReceiver.Connected += OnConnected;

            foreach (var laserReceiver in _laserReceiver) laserReceiver.LostConnection += OnDisconnect;
        }

        private void OnDisable()
        {
            foreach (var laserReceiver in _laserReceiver) laserReceiver.Connected -= OnConnected;
            foreach (var laserReceiver in _laserReceiver) laserReceiver.LostConnection -= OnDisconnect;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            //TODO
        }


        private void OnConnected()
        {
            Energy += 1;
            if (Energy > 0) _image.color = Color.white;
        }

        private void OnDisconnect()
        {
            if (Energy > 0) Energy -= 1;

            if (Energy == 0) _image.color = Color.red;
        }
    }
}