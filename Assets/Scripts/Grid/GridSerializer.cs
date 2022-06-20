#region

using System.IO;
using UnityEditor;
using UnityEngine;

#endregion

[RequireComponent(typeof(GridField))]
public class GridSerializer : MonoBehaviour
{
    private const string LevelsPath = "Assets/Resources/GridData";
    private const string LevelNamePattern = "Level_";

    private const string ExtensionJson = ".json";

    [SerializeField] private int _level;
    [SerializeField] private GridField _gridField;


    public void Save()
    {
        AssetDatabase.Refresh();
        using (var streamWriter = new StreamWriter(Path.Combine(LevelsPath, LevelNamePattern + _level + ExtensionJson)))
        {
            var json = JsonUtility.ToJson(_gridField.GetData());
            print("Save"); //
            streamWriter.Write(json);
        }
    }

    public void Load()
    {
        AssetDatabase.Refresh();
        var json = File.ReadAllText(Path.Combine(LevelsPath, LevelNamePattern + _level + ExtensionJson));
        var gridData = JsonUtility.FromJson<GridData>(json);

        print("Load"); //

        _gridField.SetData(gridData);
    }
}