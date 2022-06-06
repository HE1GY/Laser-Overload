using UnityEngine;

namespace Grid
{
   public class GridBuilderForGame : GridBuilder
    {
         private const string LaserName="Laser";
         private const string PlatformName="Platform";
         private const string BatteryName="Battery";
         private const string EmptyName="Empty";
         
         private  Laser _laser;
         private  Platform _platform;
         private  Battery _battery;
         private  Empty _empty;


        
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
        }
    }
}