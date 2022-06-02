using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class FieldBuilder : MonoBehaviour
{
    [SerializeField] private TextAsset _textFile;
    [SerializeField] private Transform[] _fieldElements;
    
    public void Save()
    {
        string path = "Assets\\Json\\"+_textFile.name+".json";
        using (StreamWriter writer = new StreamWriter(path))
        {
            string json = JsonConvert.SerializeObject(Vector3.one,Formatting.Indented,new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            print(json);
            writer.Write(json);
        }
        
        print("Save");
    }

    public void Load()
    {
        print(_textFile.text);
        
        print("Load");
    }
    
    
    
}
