using System.Collections;
using UnityEngine;

public class RabbitController : AnimationControl
{
    public float _speed = 10f;
    private void Start()
    {
        StartCoroutine(MoveLogic());

    }

    private IEnumerator MoveLogic()
    {

        SetAnimation("isRunning", true);

        Walk(_speed, target);
        yield return new WaitForSeconds(15f);
        SetAnimation("isRunning", true);

        Walk(_speed, startPos);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Bullet>())
        {
            GetComponent<SphereCollider>().enabled = false;
            GetComponentInChildren<MeshCollider>().enabled = false;

            SetAnimation("isDead_0", false);

            Destroy(gameObject, 6f);
        }
    }
}
