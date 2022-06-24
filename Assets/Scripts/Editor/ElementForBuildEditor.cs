#region

using Grid;
using UnityEditor;
using UnityEngine;

#endregion

namespace Editor
{
    [CustomEditor(typeof(ElementForBuild))]
    public class ElementForBuildEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var elementForBuild = (ElementForBuild) target;

            GUILayout.BeginVertical();

            #region Lasers

            GUILayout.BeginHorizontal();
            GUI.backgroundColor = Color.yellow;
            if (GUILayout.Button(elementForBuild._laser.texture, GUILayout.Height(50)))
                elementForBuild.ElementType = ElementType.Laser;

            GUI.backgroundColor = Color.cyan;
            if (GUILayout.Button(elementForBuild._laser3.texture, GUILayout.Height(50)))
                elementForBuild.ElementType = ElementType.Laser3;
            GUILayout.EndHorizontal();

            #endregion

            GUILayout.Space(20);

            #region Platforms

            GUILayout.BeginHorizontal();
            GUI.backgroundColor = Color.blue;
            if (GUILayout.Button(elementForBuild._platformTriangle90.texture, GUILayout.Height(50)))
                elementForBuild.ElementType = ElementType.PlatformTriangle90;

            GUI.backgroundColor = Color.magenta;
            if (GUILayout.Button(elementForBuild._platformStick90.texture, GUILayout.Height(50)))
                elementForBuild.ElementType = ElementType.PlatformStick90;
            GUILayout.EndHorizontal();

            #endregion

            GUILayout.Space(20);

            #region Receivers

            GUILayout.BeginHorizontal();
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button(elementForBuild._battery.texture, GUILayout.Height(50)))
                elementForBuild.ElementType = ElementType.Battery;

            GUI.backgroundColor = Color.green;
            if (GUILayout.Button(elementForBuild._block.texture, GUILayout.Height(50)))
                elementForBuild.ElementType = ElementType.Block;

            GUI.backgroundColor = Color.cyan;
            if (GUILayout.Button(elementForBuild._star.texture, GUILayout.Height(50), GUILayout.Width(100)))
                elementForBuild.ElementType = ElementType.Star;

            GUI.backgroundColor = Color.yellow;
            if (GUILayout.Button(elementForBuild._teleport.texture, GUILayout.Height(50)))
                elementForBuild.ElementType = ElementType.Teleport;

            GUILayout.EndHorizontal();

            #endregion

            GUILayout.Space(20);
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button(elementForBuild._empty.texture, GUILayout.Height(50)))
                elementForBuild.ElementType = ElementType.Empty;


            GUILayout.Space(20);
            GUI.backgroundColor = Color.black;
            if (GUILayout.Button("Turn", GUILayout.Height(50))) elementForBuild.Turn();

            GUILayout.EndVertical();
        }
    }
}