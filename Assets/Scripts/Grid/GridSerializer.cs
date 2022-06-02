using System;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(GridField))]
public class GridSerializer : MonoBehaviour
{
    private const string LevelsPath = "Assets/Resources/GridData";
    private const string ExtensionJson = ".json";
    
    [SerializeField] private TextAsset _saveFile;
    
     [SerializeField]private GridField _gridField;
     
    public void Save()
    {
        print("Save");//
        using (StreamWriter streamWriter=new StreamWriter(Path.Combine(LevelsPath,_saveFile.name+ExtensionJson)))
        {
            string json = JsonUtility.ToJson(_gridField.GetData());
            print(json);//
            streamWriter.Write(json);
        }
    }

    public void Load()
    {
        print("Load");//
        print(_saveFile.text);//
        GridData gridData = JsonUtility.FromJson<GridData>(_saveFile.text);
        _gridField.SetData(gridData);
        
    }
    
}
