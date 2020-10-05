using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public int _countOfShoots;
    public float _timeToReload;
    public float _timeBetveenShoots;
    public float _bulletSpeed = 10000f;
    public static int _numberOfShootInMagazin = 0;
    private Bullet[] _bullets;
    public Bullet _bulletPrefab;
    public Transform _cross;
    private bool shoot = false;
    bool reload = false;
    MagazinChange _reloadWeapon;
    GameObject crossImage;
    public Transform hammer;
    public Transform slider;
    Vector3 sliderPos;
    public GameObject bulletShellParticle;
    private void Start()
    {
        if (slider != null)
        {
            sliderPos = slider.localPosition;
        }
        crossImage = FindObjectOfType<FollowCross>().gameObject;
        _reloadWeapon = GetComponentInChildren<MagazinChange>();
        reload = true;
        StartCoroutine(InitBullets());
    }

    private IEnumerator InitBullets()
    {
        crossImage.SetActive(false);
        _bullets = new Bullet[_countOfShoots];
        _reloadWeapon.Reload();
        yield return new WaitForSeconds(_timeToReload);
        _numberOfShootInMagazin = 0;
        for (int i = 0; i < _countOfShoots; i++)
        {
            _bullets[i] = Instantiate(_bulletPrefab, _cross);
            _bullets[i].gameObject.SetActive(false);
        }
        crossImage.SetActive(true);
        if (reload)
        {
            reload = false;
        }
    }
    public float sliderMoveSpeed = 2f;
    IEnumerator MoveSlider()
    {
        if (slider != null)
        {
            while (Vector3.Distance(slider.localPosition, sliderPos) < 0.05f)
            {
                slider.localPosition = Vector3.Lerp(slider.localPosition, slider.localPosition + Vector3.forward, sliderMoveSpeed * Time.fixedDeltaTime);
                yield return new WaitForFixedUpdate();

            }
            yield return new WaitForFixedUpdate();

            while (Vector3.Distance(slider.localPosition, sliderPos) > 0.001f)
            {
                slider.localPosition = Vector3.Lerp(slider.localPosition, slider.localPosition + Vector3.back, sliderMoveSpeed * Time.fixedDeltaTime);

                yield return new WaitForFixedUpdate();

            }
        }
    }
    IEnumerator MoveHammer()
    {
        while (hammer.localEulerAngles.x > 2f)
        {
            hammer.localEulerAngles = new Vector3(hammer.localEulerAngles.x - Time.fixedDeltaTime * 500f, 360f, 360f);
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForFixedUpdate();

        while (hammer.localEulerAngles.x < 60f )
        {
            hammer.localEulerAngles = new Vector3(hammer.localEulerAngles.x + Time.fixedDeltaTime * 200f, 360f, 360f);
            yield return new WaitForFixedUpdate();
        }
        while (hammer.localEulerAngles.x > 42 && hammer.localEulerAngles.x < 62f)
        {
            hammer.localEulerAngles = new Vector3(hammer.localEulerAngles.x - Time.fixedDeltaTime * 100f, 360f, 360f);
            yield return new WaitForFixedUpdate();
        }

    }
    private IEnumerator StartShoot(int i)
    {
        if (!shoot && !reload)
        {
            yield return new WaitForSeconds(0.1f);
            bulletShellParticle.SetActive(true); ;
            InitParticle.InitShootEffect(_cross.transform.position, out GameObject shot);
            if (hammer !=null)
            {
                StartCoroutine(MoveHammer());

            }
            if (slider!=null)
            {
                StartCoroutine(MoveSlider());

            }

            shoot = true;
            _bullets[i].gameObject.SetActive(true);

            yield return new WaitForSeconds(_timeBetveenShoots);
            bulletShellParticle.SetActive(false);
            shoot = false;
            if (_numberOfShootInMagazin >= _countOfShoots)
            {
                if (!reload)
                {
                    reload = true;
                    StartCoroutine(InitBullets());
                }
            }
        }
    }
    public void Shoot()
    {
        if (_numberOfShootInMagazin < _countOfShoots)
        {
            StartCoroutine(StartShoot(_numberOfShootInMagazin));
            _numberOfShootInMagazin++;
        }
        else
        {
            if (!reload)
            {
                reload = true;
                StartCoroutine(InitBullets());
            }
        }

    }
}
