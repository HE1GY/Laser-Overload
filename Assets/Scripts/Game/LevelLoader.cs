#region

using System.Collections.Generic;
using UnityEngine;

#endregion

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private bool _AutoLoad;
    
    [SerializeField] private GridSerializer _gridSerializer;
    [SerializeField] private GridField _gridField;

    private LevelCheckPoint _levelCheckPoint;
    public int CurrentLevel { get; private set; } = 1;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        _gridField.GridBuilt += CreateLevelCheckPoint;
    }


    private void OnDisable()
    {
        _gridField.GridBuilt -= CreateLevelCheckPoint;
    }

    private void Start()
    {
        if (_AutoLoad)
        {
            LoadLevel(CurrentLevel);
        }
    }


    public void LoadLevel(int levelNumber)
    {
        _gridSerializer.Load(levelNumber);
    }

    private void CreateLevelCheckPoint(Element[] elements)
    {
        var batteryLogics = new List<BatteryLogic>();
        foreach (var element in elements)
            if (element is Battery battery)
                batteryLogics.Add(battery.BatteryLogic);

        _levelCheckPoint = new LevelCheckPoint(batteryLogics.ToArray());
        if (_AutoLoad)
        {
            _levelCheckPoint.LevelCompleted += LoadNextLevel;
        }
    }


    private void LoadNextLevel()
    {
        CurrentLevel++;
        LoadLevel(CurrentLevel);
    }
}