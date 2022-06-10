using System;
using Grid.Elements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Grid
{
    public class Star:Element
    {
        [SerializeField] private LaserReceiver[] _laserReceiver;

        [SerializeField] private Image _image;
        public override ElementType ElementType { get; set; } = ElementType.Star;
        private int Energy;

        public override void OnPointerDown(PointerEventData eventData)
        {
            //TODO
        }


        private void OnEnable()
        {
            foreach (LaserReceiver laserReceiver in _laserReceiver)
            {
                laserReceiver.Connected += OnConnected;
            }
            
            foreach (LaserReceiver laserReceiver in _laserReceiver)
            {
                laserReceiver.LostConnection+= OnDisconnect;
            }
        }

        private void OnDisable()
        {
            foreach (LaserReceiver laserReceiver in _laserReceiver)
            {
                laserReceiver.Connected -= OnConnected;
            }
            foreach (LaserReceiver laserReceiver in _laserReceiver)
            {
                laserReceiver.LostConnection -= OnDisconnect;
            }
        }


        private void OnConnected()
        {
            Energy += 1;
            if (Energy > 0)
            {
                _image.color=Color.white;
            }
        }
        
        private void OnDisconnect()
        {
            Energy -= 1;
            if (Energy == 0)
            {
                _image.color=Color.red;
            }
        }
    }
}