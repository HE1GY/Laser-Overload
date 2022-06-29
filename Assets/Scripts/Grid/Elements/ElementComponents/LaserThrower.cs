#region

using System;
using System.Collections;
using UnityEngine;

#endregion

namespace Grid.Elements
{
    public class LaserThrower : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoints;
        [SerializeField] private bool _isTurnOn;

        private LaserReceiver _connectedConsumer;
        private Collider2D _connectedPort;

        private Transform _laserEdge;
        private RaycastHit2D _raycastHit2D;

        public Action<Transform> DrawCall;
        public Action DrawClean;
        public Action ResetEnergy;

        public bool IsFirstSideConnection { get; set; }


        public int ReceivedEnergy { get; set; }

        public bool IsTurnOn => ReceivedEnergy > 0 || _isTurnOn;

        public Transform ShootPoint => _shootPoints;

        private void Start()
        {
            var gm = new GameObject();
            _laserEdge = gm.transform;
            gm.hideFlags = HideFlags.HideInHierarchy;
            CallDrawing();
        }

        private void Update()
        {
            if (IsTurnOn) ThrowLaser();
        }


        private void ThrowLaser()
        {
            _raycastHit2D = Physics2D.Raycast(_shootPoints.position, _shootPoints.right);
            if (_raycastHit2D)
            {
                _laserEdge.position = _raycastHit2D.point;
                if (_raycastHit2D.collider.gameObject.TryGetComponent(out LaserReceiver laserReceiver))
                    if (laserReceiver != _connectedConsumer)
                    {
                        ResetConsumer();
                        
                        _connectedPort = _raycastHit2D.collider;
                        _connectedConsumer = laserReceiver;
                        if (!IsFirstSideConnection) Connect();
                    }


                Debug.DrawRay(_shootPoints.position, _shootPoints.right * _raycastHit2D.distance, Color.black); //
            }
            else
            {
                ResetConsumer();
            }
        }

        public void ResetAll()
        {
            ResetEnergy?.Invoke();
            ReceivedEnergy = 0;
            ResetConsumer();
            CallDrawing();
        }

        public void ResetConsumer()
        {
            if (_connectedPort)
            {
                _connectedConsumer?.Disconnect(_connectedPort);
                _connectedConsumer = null;
                _connectedPort = null;
                _laserEdge.position = ShootPoint.position;
            }
        }

        public void Connect()
        {
            if (_connectedConsumer)
            {
                var connected = _connectedConsumer.TryConnect(_raycastHit2D.collider);
                if (!connected) ResetConsumer();
            }
        }


        private void CallDefaultDraw()
        {
            var defaultLaserLength = 2.5f;
            var laserEdge = _shootPoints.right * defaultLaserLength + _shootPoints.position;
            _laserEdge.position = laserEdge;
            DrawCall?.Invoke(_laserEdge);
        }

        private void CallHitDraw()
        {
            _laserEdge.position = _raycastHit2D.point;
            DrawCall?.Invoke(_laserEdge);
        }

        public void CallDrawing()
        {
            IsFirstSideConnection = true;
            StartCoroutine(FrameSkipDraw()); // firstly throw laser 
        }

        private IEnumerator FrameSkipDraw()
        {
            DrawClean?.Invoke();
            yield return null;
            if (IsTurnOn)
            {
                if (_connectedPort)
                    CallHitDraw();
                else
                    CallDefaultDraw();
            }
        }
    }
}