using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoockAtCross : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cross;
 
    void Update()
    {
        transform.LookAt(cross);
    }
}
