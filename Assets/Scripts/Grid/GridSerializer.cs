using System;
using System.IO;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(GridField))]
public class GridSerializer : MonoBehaviour
{
    private const string LevelsPath = "Assets/Resources/GridData";
    private const string ExtensionJson = ".json";
    
    [SerializeField] private TextAsset _saveFile;
    [SerializeField]private GridField _gridField;

    /*private void Start()
    {
        Load();
    }
    private void OnDisable() // auto save/load
    {
        Save();
    }*/

    public void Save()
    {
        using (StreamWriter streamWriter=new StreamWriter(Path.Combine(LevelsPath,_saveFile.name+ExtensionJson)))
        {
            string json = JsonUtility.ToJson(_gridField.GetData());
            print("Save");//
            streamWriter.Write(json);
        }
    }

    public void Load()
    {
        AssetDatabase.Refresh();
        GridData gridData = JsonUtility.FromJson<GridData>(_saveFile.text);
        print("Load");//
        _gridField.SetData(gridData);
    }
    
}
