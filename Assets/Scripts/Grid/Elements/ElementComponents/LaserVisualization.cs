#region

using System.Collections;
using Grid.Elements;
using UnityEngine;

#endregion

public class LaserVisualization : MonoBehaviour
{
    private const float _speed = 0.014f;

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private LaserThrower _laserThrower;

    private Transform _laserEdge;


    private void OnEnable()
    {
        _laserThrower.DrawCall += HandleLaserVisualization;
        _laserThrower.DrawClean += ResetRender;
    }

    private void OnDisable()
    {
        _laserThrower.DrawCall -= HandleLaserVisualization;
        _laserThrower.DrawClean -= ResetRender;
    }


    private void HandleLaserVisualization(Transform laserEdge)
    {
        _laserEdge = laserEdge;
        ResetRender();
        StartCoroutine(LaserGrowing(laserEdge.position));
    }

    private IEnumerator LaserGrowing(Vector3 LaserEdge)
    {
        var laserTip = _laserThrower.ShootPoint.position;
        _lineRenderer.SetPosition(0, laserTip);
        float lerpValue = 0;

        while (lerpValue < 1)
        {
            lerpValue += Time.deltaTime + _speed;
            laserTip = Vector2.Lerp(_laserThrower.ShootPoint.position, LaserEdge, lerpValue);
            _lineRenderer.SetPosition(1, laserTip);
            yield return null;
        }

        _laserThrower.Connect();
        _laserThrower.IsFirstSideConnection = false;
        StartCoroutine(LaserLengthControlling());
    }

    private IEnumerator LaserLengthControlling()
    {
        while (true)
        {
            _lineRenderer.SetPosition(1, _laserEdge.position);
            yield return null;
        }
    }

    private void ResetRender()
    {
        StopAllCoroutines();
        _lineRenderer.SetPosition(0, _laserThrower.ShootPoint.position);
        _lineRenderer.SetPosition(1, _laserThrower.ShootPoint.position);
    }
}