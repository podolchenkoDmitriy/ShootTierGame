using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCross : MonoBehaviour
{
    public GameObject cross;
    public float smooth = 0.05f;
    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Camera.main.WorldToScreenPoint(cross.transform.position), smooth);
    }
}
