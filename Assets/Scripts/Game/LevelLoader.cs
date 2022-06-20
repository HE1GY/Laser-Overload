using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GridSerializer _gridSerializer;


    public void LoadLevel(int levelNumber)
    {
        _gridSerializer.Load(levelNumber);
    }
    
    
}
