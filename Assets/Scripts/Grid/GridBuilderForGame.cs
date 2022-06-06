using UnityEngine;

namespace Grid
{
   public class GridBuilderForGame : GridBuilder
    {
         private const string LaserName=" ";//TODO name
         private const string PlatformName=" ";
         private const string BatteryName=" ";
         private const string EmptyName=" ";
         
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
                        gridElements[i] = Instantiate(_laser, Vector3.zero, Quaternion.Euler(0,0,gridData.StartRotations[i]));
                        break;
                    case ElementType.Platform:
                        gridElements[i] = Instantiate(_platform, Vector3.zero, Quaternion.Euler(0,0,gridData.StartRotations[i]));
                        break;
                    case ElementType.Battery:
                        gridElements[i] = Instantiate(_battery, Vector3.zero, Quaternion.Euler(0,0,gridData.StartRotations[i]));
                        break;
                    case ElementType.Empty:
                        gridElements[i] = Instantiate(_empty, Vector3.zero, Quaternion.Euler(0,0,gridData.StartRotations[i]));
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