using UnityEditor;
using UnityEngine;


namespace Editor
{
    [CustomEditor((typeof(GridSerializer)))]
    public class SaveLoadGrid:UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            GridSerializer gridSerializer = (GridSerializer) target;
            if (GUILayout.Button("Save Grid"))
            {
                gridSerializer.Save();
            }
            else if(GUILayout.Button("Load Grid"))
            {
                gridSerializer.Load();
            }
        }
    }
}