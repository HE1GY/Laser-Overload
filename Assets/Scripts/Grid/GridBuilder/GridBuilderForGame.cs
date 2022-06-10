using UnityEngine;

namespace Grid
{
   public class GridBuilderForGame : GridBuilder
    {
         private const string LaserName="Laser[1]";
         private const string PlatformTriangle90Name="Platform[Triangle90]";
         private const string PlatformStick90Name="Platform[Stick90]";
         private const string BatteryName="Battery";
         private const string EmptyName="Empty";
         private const string Laser3Name="Laser[3]";
         private const string BlockName="Block";
         private const string StarName="Star";

         private  Laser _laser;
         private  PlatformTriangle90 _platformTriangle90;
         private  PlatformStick90 _platformStick90;
         private  Battery _battery;
         private  Empty _empty;
         private  Laser3 _laser3;
         private  Block _block;
         private  Star _star;


        
        public override Element[] BuildGrid(ref GridData gridData)
        {
            LoadAllElements();
            int elementCount = gridData.Columns * gridData.Rows;
            Element[] gridElements = new Element[elementCount];
            for (int i = 0; i < elementCount; i++)
            {
                switch (gridData.ElementTypes[i])
                {
                    case ElementType.Laser:
                        gridElements[i] = Instantiate(_laser, Vector2.zero, Quaternion.Euler(0,0,gridData.StartRotations[i]),transform);
                        break;
                    case ElementType.PlatformTriangle90:
                        gridElements[i] = Instantiate(_platformTriangle90, Vector2.zero, Quaternion.Euler(0,0,gridData.StartRotations[i]),transform);
                        break;
                    case ElementType.PlatformStick90:
                        gridElements[i] = Instantiate(_platformStick90, Vector2.zero, Quaternion.Euler(0,0,gridData.StartRotations[i]),transform);
                        break;
                    case ElementType.Battery:
                        gridElements[i] = Instantiate(_battery, Vector2.zero, Quaternion.Euler(0,0,gridData.StartRotations[i]),transform);
                        break;
                    case ElementType.Empty:
                        gridElements[i] = Instantiate(_empty, Vector2.zero, Quaternion.Euler(0,0,gridData.StartRotations[i]),transform);
                        break;
                    case ElementType.Laser3 :
                        gridElements[i] = Instantiate(_laser3, Vector2.zero, Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                    case ElementType.Block :
                        gridElements[i] = Instantiate(_block, Vector2.zero, Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                    case ElementType.Star :
                        gridElements[i] = Instantiate(_star, Vector2.zero, Quaternion.Euler(0, 0, gridData.StartRotations[i]), transform);
                        break;
                }
            }
            return gridElements;
        }

        private void LoadAllElements()
        {
            _laser = LoadGridElement(LaserName) as Laser;
            _platformTriangle90 = LoadGridElement(PlatformTriangle90Name) as PlatformTriangle90;
            _platformStick90 = LoadGridElement(PlatformStick90Name) as PlatformStick90;
            _battery = LoadGridElement(BatteryName) as Battery;
            _empty = LoadGridElement(EmptyName) as Empty;
            _laser3=LoadGridElement(Laser3Name)as Laser3;
            _block=LoadGridElement(BlockName) as Block;
            _star=LoadGridElement(StarName) as Star;
        }
    }
}