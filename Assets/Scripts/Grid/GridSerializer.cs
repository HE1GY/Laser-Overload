using System.IO;
using UnityEngine;

public class GridSerializer : MonoBehaviour
{
    private const string LevelsPath = "Assets/Resources/GridData";
    private const string ExtensionJson = ".json";


    [SerializeField] private TextAsset _saveFile;
    [SerializeField] private GridField _GridField;


    public void Save()
    {
        print("Save");//
        using (StreamWriter streamWriter=new StreamWriter(Path.Combine(LevelsPath,_saveFile.name+ExtensionJson)))
        {
            string json = JsonUtility.ToJson(_GridField.GetData());
            print(json);//
            streamWriter.Write(json);
        }
    }

    public void Load()
    {
        print("Load");//
        
    }
    
}
