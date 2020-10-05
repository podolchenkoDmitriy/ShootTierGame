using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGO : MonoBehaviour
{
    Rigidbody rb;
    public float force = 2000f;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * force, ForceMode.Force);
        
    }
}
