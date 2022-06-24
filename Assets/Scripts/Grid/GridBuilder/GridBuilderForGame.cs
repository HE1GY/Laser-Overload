#region

using Grid.Elements;
using UnityEngine;

#endregion

namespace Grid
{
    public class GridBuilderForGame : GridBuilder
    {
        private const string LaserName = "Laser[1]";
        private const string PlatformTriangle90Name = "Platform[Triangle90]";
        private const string PlatformStick90Name = "Platform[Stick90]";
        private const string BatteryName = "Battery";
        private const string EmptyName = "Empty";
        private const string Laser3Name = "Laser[3]";
        private const string BlockName = "Block";
        private const string StarName = "Star";
        private const string TeleportName = "Teleport";
        private Battery _battery;
        private Block _block;
        private Empty _empty;

        private Laser _laser;
        private Laser3 _laser3;
        private PlatformStick90 _platformStick90;
        private PlatformTriangle90 _platformTriangle90;
        private Star _star;
        private Teleport _teleport;


        private Teleport _tp1;
        private Teleport _tp2;


        public override Element[] BuildGrid(ref GridData gridData)
        {
            LoadAllElements();
            var elementCount = gridData.Columns * gridData.Rows;
            var gridElements = new Element[elementCount];
            for (var i = 0; i < elementCount; i++)
                switch (gridData.ElementTypes[i])
                {
                    case ElementType.Laser:
                        gridElements[i] = Instantiate(_laser, Vector2.zero,
                            Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                    case ElementType.PlatformTriangle90:
                        gridElements[i] = Instantiate(_platformTriangle90, Vector2.zero,
                            Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                    case ElementType.PlatformStick90:
                        gridElements[i] = Instantiate(_platformStick90, Vector2.zero,
                            Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                    case ElementType.Battery:
                        gridElements[i] = Instantiate(_battery, Vector2.zero,
                            Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                    case ElementType.Empty:
                        gridElements[i] = Instantiate(_empty, Vector2.zero,
                            Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                    case ElementType.Laser3:
                        gridElements[i] = Instantiate(_laser3, Vector2.zero,
                            Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                    case ElementType.Block:
                        gridElements[i] = Instantiate(_block, Vector2.zero,
                            Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                    case ElementType.Star:
                        gridElements[i] = Instantiate(_star, Vector2.zero,
                            Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                    case ElementType.Teleport:
                        gridElements[i] = Instantiate(_teleport, Vector2.zero,
                            Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        InitializeTeleport(gridElements, i);
                        break;
                }

            return gridElements;
        }

        private void InitializeTeleport(Element[] gridElements, int i)
        {
            if (!_tp1)
            {
                _tp1 = (Teleport) gridElements[i];
            }
            else if (!_tp2)
            {
                _tp2 = (Teleport) gridElements[i];
                var tp1L = _tp1.ElementLogic as TeleportLogic;
                var tp2L = _tp2.ElementLogic as TeleportLogic;
                tp1L.gameObject.SetActive(false);
                tp2L.gameObject.SetActive(false);
                tp1L.SetLaserReceiversToLaser(tp2L.LaserReceivers);
                tp2L.SetLaserReceiversToLaser(tp1L.LaserReceivers);
                tp1L.gameObject.SetActive(true);
                tp2L.gameObject.SetActive(true);
            }
        }

        private void LoadAllElements()
        {
            _laser = LoadGridElement(LaserName) as Laser;
            _platformTriangle90 = LoadGridElement(PlatformTriangle90Name) as PlatformTriangle90;
            _platformStick90 = LoadGridElement(PlatformStick90Name) as PlatformStick90;
            _battery = LoadGridElement(BatteryName) as Battery;
            _empty = LoadGridElement(EmptyName) as Empty;
            _laser3 = LoadGridElement(Laser3Name) as Laser3;
            _block = LoadGridElement(BlockName) as Block;
            _star = LoadGridElement(StarName) as Star;
            _teleport = LoadGridElement(TeleportName) as Teleport;
        }
    }
}