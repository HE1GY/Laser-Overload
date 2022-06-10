using System;
using System.Collections;
using System.Text;
using Grid.Elements;
using UnityEngine;

public class LaserVisualization : MonoBehaviour
{
    private const float DefaultLaserLength= 2.5f;
   
   [SerializeField] private LineRenderer _lineRenderer;
   [SerializeField] private LaserThrower _laserThrower;
   

   private bool _startedVisualization;
   private Vector3 _defaultPoint;
   private bool _hasAim;
   

   private void Update()
   {
       HandleLaserVisualization();
   }

   private void HandleLaserVisualization()
   {
       /*_defaultPoint=_laserThrower.ShootPoint.right *
           DefaultLaserLength + _laserThrower.ShootPoint.position;
       if (_laserThrower.IsTurnOn && !_startedVisualization)
       {
           _hasAim = _laserThrower.HitInfo;
           _startedVisualization = true;
           if (_hasAim)
           {
               StartCoroutine(LaserGrowing(_laserThrower.HitInfo.point));
           }
           else
           {
               StartCoroutine(LaserGrowing(_defaultPoint));
           }
       }
       
       if (!_laserThrower.IsTurnOn || _hasAim!= _laserThrower.HitInfo && _startedVisualization)
       {
           StopAllCoroutines();
           _startedVisualization = false;
           ResetRender();
       }*/
       
       
       
   }


   private IEnumerator LaserGrowing(Vector3 LaserEdge)
   {
       Vector3 laserTip = _laserThrower.ShootPoint.position;
       _lineRenderer.SetPosition(0,laserTip);
       float lerpValue=0;

       while (lerpValue < 1)
       {
           lerpValue += Time.deltaTime;
           laserTip = Vector2.Lerp(_laserThrower.ShootPoint.position, LaserEdge, lerpValue);
           _lineRenderer.SetPosition(1,laserTip);
           yield return null;
       }
   }

   private void ResetRender()
   {
       _lineRenderer.SetPosition(0, _laserThrower.ShootPoint.position);
       _lineRenderer.SetPosition(1, _laserThrower.ShootPoint.position);
   }
}
