using UnityEngine;

namespace Grid.Elements
{
    public class LaserThrower:MonoBehaviour
    {
        [SerializeField] private Transform _shootPoints;
        [SerializeField]private bool _isThrowingLaser;//
        [SerializeField] private LineRenderer _LineRenderer;
        
        public bool IsThrowingLaser
        {
            set => _isThrowingLaser=value;
        }
        
        private LaserReceiver _connectedConsumer;
        private Collider2D _connectedPort;
        private RaycastHit2D _raycastHit2D;

        
        private void Update()
        {
            if (_isThrowingLaser)
            {
                ThrowLaser();
                /*HandleLaserVisualization();*/
            }
        }
        
        private void ThrowLaser()
        {
            _raycastHit2D = Physics2D.Raycast(_shootPoints.position, _shootPoints.right);
            
            Debug.DrawRay(_shootPoints.position,_shootPoints.right*100,Color.red);//
            
            if (_raycastHit2D && _raycastHit2D.collider.gameObject.TryGetComponent(out LaserReceiver laserReceiver))
            {
                if (laserReceiver != _connectedConsumer)
                {
                    _connectedConsumer?.Disconnect(_connectedPort);
                    bool connect=laserReceiver.TryConnect(_raycastHit2D.collider);
                    if (connect)
                    {
                        _connectedPort = _raycastHit2D.collider;
                        _connectedConsumer = laserReceiver;
                    }
                }
            }
            else
            {
                StopThrowing();
            }
        }


        public void StopThrowing()
        {
            if(_connectedConsumer)
            {
                _connectedConsumer.Disconnect(_connectedPort);
                _connectedConsumer = null;
            }
        }
        


        private void HandleLaserVisualization()
        {
            Vector3[] positions = new Vector3[] {_shootPoints.position,_raycastHit2D.point };
            _LineRenderer.SetPositions(positions);
        }
    }
}