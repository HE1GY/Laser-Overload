#region

using Grid.Elements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#endregion

internal class Battery : Element
{
    [SerializeField] private Image _testMark; //test
    [SerializeField] private LaserReceiver _laserReceiver;

    private int Energy;
    public override ElementType ElementType { get; set; } = ElementType.Battery;


    private void OnEnable()
    {
        _laserReceiver.Connected += OnConnect;
        _laserReceiver.LostConnection += OnDisconnect;
    }

    private void OnDisable()
    {
        _laserReceiver.Connected -= OnConnect;
        _laserReceiver.LostConnection -= OnDisconnect;
    }


    private void OnConnect()
    {
        Energy += 1;
        if (Energy > 0) _testMark.enabled = true;
    }

    private void OnDisconnect()
    {
        if (Energy > 0) Energy -= 1;
        if (Energy == 0) _testMark.enabled = false;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        //TODO 
    }
}