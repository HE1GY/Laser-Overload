using UnityEngine;

namespace Grid
{
   public class GridBuilderForGame : GridBuilder
    {
         private const string LaserName="Laser[1]";
         private const string PlatformName="Platform[Triangle90]";
         private const string BatteryName="Battery";
         private const string EmptyName="Empty";
         private const string Laser3Name="Laser[3]";
         
         private  Laser _laser;
         private  Platform _platform;
         private  Battery _battery;
         private  Empty _empty;
         private  Laser3 _laser3;


        
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
                    case ElementType.Platform:
                        gridElements[i] = Instantiate(_platform, Vector2.zero, Quaternion.Euler(0,0,gridData.StartRotations[i]),transform);
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
                }
            }
            return gridElements;
        }

        private void LoadAllElements()
        {
            _laser = LoadGridElement(LaserName) as Laser;
            _platform = LoadGridElement(PlatformName) as Platform;
            _battery = LoadGridElement(BatteryName) as Battery;
            _empty = LoadGridElement(EmptyName) as Empty;
            _laser3=LoadGridElement(Laser3Name)as Laser3;
        }
    }
}