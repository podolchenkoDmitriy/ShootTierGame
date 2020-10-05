using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossMovement : MonoBehaviour
{
    [Header("Crosshair movement")]
    [SerializeField] private float _moveSpeed = 5f;
    public static bool _isMousePressed = false;
     Vector3 startDir;
     Vector3 dir;

    public float moveSpeedInput = 60f;
    public float _smooth = 0.25f;
    private void FixedUpdate()
    {
        ClampPosition();
        //move the crosshair
        if (_isMousePressed)
        {
            dir = new Vector3(Input.GetAxis("Mouse X") * moveSpeedInput * Time.fixedDeltaTime, Input.GetAxis("Mouse Y") * moveSpeedInput * Time.fixedDeltaTime * 0.8f, 0);
            if (dir == Vector3.zero)
            {
                startDir = -new Vector3(0.5f, 0.5f, 0) + Camera.main.ScreenToViewportPoint(Input.mousePosition);
                transform.position = Vector3.Lerp(transform.position, transform.position + startDir, _moveSpeed * Time.fixedDeltaTime);

            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + dir * moveSpeedInput * Time.fixedDeltaTime, _smooth);
            }


        }

    }
    private void ClampPosition()
    {
        //player's boundaries in case of camera viewport
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.001f, 1f);
        pos.y = Mathf.Clamp(pos.y, 0.05f, 0.95f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            _isMousePressed = true;

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            _isMousePressed = false;
        }
    }
}
