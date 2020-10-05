using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Levels/Level", fileName = "Level")]

public class Levels : ScriptableObject
{
    [Header ("NumberOfCurrentLevel")]
    public int level;

    public int Level { get => level; }

    [Header ("CountOfItemsOnLevel")]
    public int countItemsOnLevel;

    public int CountItemsOnLevel { get => countItemsOnLevel; }

    [Header("PrefabsToInit")]

    public GameObject[] prefabs;

    public GameObject[] PrefabsToInit { get => prefabs; }
}
