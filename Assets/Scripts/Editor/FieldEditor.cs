using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GridField))]
    public class FieldEditor:UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GridField gridField = (GridField) target;
            if (GUILayout.Button("Clean Field"))
            {
                gridField.Clean();
            }
        }


        public static void RunForGridSerializerEditor(GridSerializer gridSerializer)
        {
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