using System.Collections;
using UnityEngine;

public class DeerController : AnimationControl
{
    // Start is called before the first frame update
    public float _speed = 10f;

    private void Start()
    {
        StartCoroutine(MoveLogic());
       
    }

    IEnumerator MoveLogic()
    {
        SetAnimation("isWalking",true);

        Walk(_speed, target);
        yield return new WaitForSeconds(30f);
        SetAnimation("isWalking",true);

        Walk(_speed, startPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            SetAnimation("isDead",false);
            GetComponent<SphereCollider>().enabled = false;
            GetComponentInChildren<MeshCollider>().enabled = false;

            Destroy(gameObject, 6f);
        }
    }

}
