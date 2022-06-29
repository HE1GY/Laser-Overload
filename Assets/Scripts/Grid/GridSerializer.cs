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

     public int Level;
    [SerializeField] private GridField _gridField;


    public void Save()
    {
        AssetDatabase.Refresh();
        using (var streamWriter = new StreamWriter(Path.Combine(LevelsPath, LevelNamePattern + Level + ExtensionJson)))
        {
            var json = JsonUtility.ToJson(_gridField.GetData());
            print("Save"); //
            streamWriter.Write(json);
        }
    }

    public void Load(int level)
    {
        AssetDatabase.Refresh();
        var json = File.ReadAllText(Path.Combine(LevelsPath, LevelNamePattern + level + ExtensionJson));
        var gridData = JsonUtility.FromJson<GridData>(json);

        print("Load"); //

        _gridField.SetData(gridData);
    }
}