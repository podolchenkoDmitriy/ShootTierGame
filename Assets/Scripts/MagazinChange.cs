using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazinChange : MonoBehaviour
{

    Vector3 nativePos;
    public float changeSpeed = 10f;
    public Transform slider;
    public Transform hammer;
    Vector3 sliderPos;
    void Start()
    {
        nativePos = transform.localPosition;
        if (slider !=null)
        {
            sliderPos = slider.localPosition;
        }
    }

    public void Reload()
    {
        StartCoroutine(ChangeMagazin());

    }
    IEnumerator ChangeMagazin()
    {
        while (Vector3.Distance(transform.localPosition, nativePos) < 1f )
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + Vector3.down, changeSpeed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForFixedUpdate();
        while (Vector3.Distance(transform.localPosition, nativePos) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + Vector3.up, changeSpeed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
        if (slider !=null)
        {
            while (Vector3.Distance(slider.localPosition, sliderPos) < 0.2f)
            {
                slider.localPosition = Vector3.Lerp(slider.localPosition, slider.localPosition + Vector3.forward, changeSpeed * Time.fixedDeltaTime);
                hammer.localEulerAngles = new Vector3(hammer.localEulerAngles.x + changeSpeed * Time.fixedDeltaTime*150f, 360f, 360f);
                yield return new WaitForFixedUpdate();

            }
            yield return new WaitForFixedUpdate();

            while (Vector3.Distance(slider.localPosition, sliderPos) > 0.001f)
            {
                slider.localPosition = Vector3.Lerp(slider.localPosition, slider.localPosition + Vector3.back, changeSpeed * Time.fixedDeltaTime);
                hammer.localEulerAngles = new Vector3(hammer.localEulerAngles.x - changeSpeed * Time.fixedDeltaTime * 150f, 360f, 360f);

                yield return new WaitForFixedUpdate();

            }
        }

    }

}
