using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Levels[] level;
    private int currentLevel;
    private int countOfItemsOnLevel;

    public Transform parent;

    public static int numberOfCurrentLevel;
    private Transform[] itemsOnLevel = null;
    private GameObject[] prefabs;

    public static List<Transform> newObjects = new List<Transform>();
    private void Awake()
    {
        currentLevel = level[numberOfCurrentLevel].Level;
        countOfItemsOnLevel = level[currentLevel].CountItemsOnLevel;

        prefabs = level[currentLevel].PrefabsToInit;

        StartCoroutine(InitObjects());
    }

    private IEnumerator InitObjects()
    {
        itemsOnLevel = new Transform[countOfItemsOnLevel];
        for (int i = 0; i < countOfItemsOnLevel; i++)
        {
            int k = Random.Range(0, prefabs.Length);
            itemsOnLevel[i] = Instantiate(prefabs[k].transform, parent);
            newObjects.Add(itemsOnLevel[i]);
            itemsOnLevel[i].gameObject.SetActive(false);
            yield return null;
        }
    }
}
