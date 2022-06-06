using System.IO;
using Unity.Mathematics;
using UnityEngine;

namespace Grid
{
    public abstract class GridBuilder:MonoBehaviour
    {
        private const string AllGridElementFolder="Prefabs/GridElements";
        public abstract Element[] BuildGrid(ref GridData gridData);
        protected Element LoadGridElement(string elementName)
        {
            Element element= Resources.Load<Element>(Path.Combine(AllGridElementFolder,elementName));
            if (!element)
            {
                Debug.LogError("Error while loading prefab");
            }
            return element;
        }
    }
}