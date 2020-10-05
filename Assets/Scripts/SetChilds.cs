using System.Collections;
using UnityEngine;

public class SetChilds : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform[] objects;
    public float waitTime = 0.5f;
    public float _throwPower = 100f;
    private void Start()
    {
        StartCoroutine(GetObjects());
    }

    private IEnumerator GetObjects()
    {
        yield return new WaitForSeconds(waitTime);
        objects = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            objects[i] = LevelManager.newObjects[i];
        }
        LevelManager.newObjects.Clear();
        yield return StartCoroutine(EnableObjects());
    }


    IEnumerator EnableObjects()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            yield return new WaitForSeconds(waitTime);
            objects[i].gameObject.SetActive(true);
            
        }
    }
}
