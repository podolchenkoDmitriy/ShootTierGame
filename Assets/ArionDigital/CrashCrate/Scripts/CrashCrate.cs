
using System.Collections;
using UnityEngine;

public class CrashCrate : MonoBehaviour
{
    [Header("Whole Create")]
    public MeshRenderer wholeCrate;
    BoxCollider[] boxCollider;
    [Header("Fractured Create")]
    public GameObject fracturedCrate;

    private Rigidbody rb;
    private Vector3 pos;
    private float _force;

    private void Awake()
    {
        _force = transform.parent.GetComponent<SetChilds>()._throwPower;
        boxCollider = GetComponentsInChildren<BoxCollider>();
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = new Vector3(0.5f*(-transform.position.x + Camera.main.transform.position.x), 1, transform.position.x - Camera.main.transform.position.x);
        rb.AddForce( pos * _force, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            Vector3 vel = rb.velocity;
            wholeCrate.enabled = false;
            foreach (var item in boxCollider)
            {
                item.enabled = false;

            }
            fracturedCrate.SetActive(true);
            Rigidbody[] rigid = GetComponentsInChildren<Rigidbody>();
            foreach (var item in rigid)
            {
                item.velocity += vel;
            }

            StartCoroutine(OffObjects());
        }
    }
    
    IEnumerator OffObjects()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
}
