using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Transform parent;
    float bulletSpeed;
    void Awake()
    {
        parent = transform.parent;
        rb = GetComponent<Rigidbody>();
    }
    void Destroying()
    {
        Destroy(gameObject);
    }
     
    IEnumerator StartCountDistance()
    {
        yield return new WaitForFixedUpdate();
        transform.parent = null;
        while (gameObject.activeInHierarchy)
        {

            if (Vector3.Distance(transform.position, parent.position) > 100000f)
            {
                yield return new WaitForFixedUpdate();
                Destroying();
            }
            yield return null;
        }
       
    }
    
    private void OnEnable()
    {
        bulletSpeed = GetComponentInParent<Weapon>()._bulletSpeed;
        Vector3 forward = -transform.parent.transform.forward;
        rb.AddForce(forward * bulletSpeed, ForceMode.Force);
        StartCoroutine(StartCountDistance());
    }
    private void OnCollisionEnter(Collision collision)
    {


        
        if(collision.collider.CompareTag("Rock"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;
            InitParticle.InitRockParticle(pos, out GameObject rock);
            Destroying();

            //Destroy(rock, 10f);
        }
        else
        {
            Destroying();

        }
    }
}
