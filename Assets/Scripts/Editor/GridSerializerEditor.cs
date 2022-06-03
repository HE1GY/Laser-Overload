using UnityEditor;


namespace Editor
{
    [CustomEditor(typeof(GridSerializer))]
    public class GridSerializerEditor:UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            FieldEditor.RunForGridSerializerEditor((GridSerializer)target);
        }
    }
}