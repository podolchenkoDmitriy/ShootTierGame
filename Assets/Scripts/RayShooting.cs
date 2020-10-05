using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooting : MonoBehaviour
{
    public float _aimDistance = 100f;
    Ray _crossRay;
    public LayerMask _layerMask;
    public Transform _cross;
    Weapon _shooting;
    // Start is called before the first frame update
    void Start()
    {
        _shooting = GetComponent<Weapon>();
    }

    // Update is called once per frame
    Ray Hit()
    {
        Ray hit = new Ray(_cross.position, -_cross.forward * _aimDistance);
        Debug.DrawRay(hit.origin, hit.direction * _aimDistance, Color.red);
        _crossRay = hit;

        return _crossRay;
    }
    bool shooted = false;
    void Update()
    {
        Hit();
        if (Physics.Raycast(_crossRay.origin, _crossRay.direction, _aimDistance, _layerMask))
        {
            if (!shooted)
            {
                shooted = true;
                _shooting.Shoot();
                StartCoroutine(CountTimebetweenShoots());
            }
        }
    }
    IEnumerator CountTimebetweenShoots()
    {
        yield return new WaitForSeconds(_shooting._timeBetveenShoots);
        shooted = false;
    }
}
