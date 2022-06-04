using UnityEngine;

public class LaserRelay
{
    private LaserRelаyData _laserRelаyData;
    private bool _canThrowRay;
    private bool _rayConnected;
    private Collider2D _currentConnectedReceiver;

    public LaserRelay(LaserRelаyData laserRelаyData,bool canThrowRay=false)
    {
        _canThrowRay = canThrowRay;
        _laserRelаyData = laserRelаyData;
    }

    public bool TryReceived(Collider2D collider2D)
    {
        _canThrowRay = _laserRelаyData._laserReciversCollider.Equals(collider2D);
        Debug.Log($"try receive{_canThrowRay}");
        return _canThrowRay;
    }


    public void HandleLaserThrowing()
    {
        if (_canThrowRay && _laserRelаyData._laserShootPoint)
        {
            ThrowLaser();
        }
    }

    private void ThrowLaser()
    {
        Transform shootPointTransform = _laserRelаyData._laserShootPoint;
        
        RaycastHit2D raycastHit2D;
        raycastHit2D = Physics2D.Raycast(shootPointTransform.position, shootPointTransform.right,float.MaxValue);
        Debug.DrawRay(shootPointTransform.position,shootPointTransform.right*100,Color.red);
            
        if (raycastHit2D && raycastHit2D.collider.gameObject.TryGetComponent(out LaserInteractor laserInteractor))
        {
            if (!_rayConnected)
            {
                _rayConnected=laserInteractor.TryDoRayInteraction(raycastHit2D.collider);
                if (_rayConnected)
                {
                    _currentConnectedReceiver = raycastHit2D.collider;
                }
            }
            Debug.Log("Laser interactor");
        }
    }
}