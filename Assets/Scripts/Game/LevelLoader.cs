#region

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private bool _AutoLoad;

    [SerializeField] private GridSerializer _gridSerializer;
    [SerializeField] private GridField _gridField;

    public LevelFinisher LevelFinisher;
    public int CurrentLevel { get; private set; } = 1;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if (_AutoLoad) LoadLevel(CurrentLevel);
    }

    private void OnEnable()
    {
        _gridField.GridBuilt += CreateLevelFinisher;
    }


    private void OnDisable()
    {
        _gridField.GridBuilt -= CreateLevelFinisher;
    }


    public void LoadLevel(int levelNumber)
    {
        _gridSerializer.Load(levelNumber);
    }

    private void CreateLevelFinisher(Element[] elements)
    {
        var levelCheckPoints = GetLevelCheckPoints(elements);

        LevelFinisher = new LevelFinisher(levelCheckPoints);
        if (_AutoLoad) LevelFinisher.LevelCompleted += OnLevelCompleted;
    }

    private static ILevelCheckPoint[] GetLevelCheckPoints(Element[] elements)
    {
        var elementLogics = elements.Select(e => e.ElementLogic).ToArray();
        var levelCheckPoints = new List<ILevelCheckPoint>();
        foreach (var elementLogic in elementLogics)
            if (elementLogic is ILevelCheckPoint levelCheckPoint)
                levelCheckPoints.Add(levelCheckPoint);
        return levelCheckPoints.ToArray();
    }



    private void OnLevelCompleted()
    {
        print($"{CurrentLevel} level completed");
        LoadNextLevel();
    }

    private void LoadNextLevel() //test TODO
    {
        CurrentLevel++;
        StartCoroutine(DelayedLoad());
    }

    private IEnumerator DelayedLoad()
    {
        yield return new WaitForSeconds(0.5f);
        LoadLevel(CurrentLevel);
    }
}