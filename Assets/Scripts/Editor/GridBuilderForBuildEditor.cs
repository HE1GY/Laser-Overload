#region

using Grid;
using UnityEditor;

#endregion

namespace Editor
{
    [CustomEditor(typeof(GridBuilderForBuild))]
    public class GridBuilderForBuildEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GridFieldEditor.DrawBuildButton();
        }
    }
}