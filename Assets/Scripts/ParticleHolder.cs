using UnityEngine;

public class ParticleHolder : MonoBehaviour
{
    [Space]
    [Header("BigExplousion")]
    public GameObject rocksParticke;
    public static GameObject RockParticle { get; set; }
    [Space]
    [Header("Explousion")]

    public GameObject shootEffect;
    public static GameObject ShootEffect { get; set; }
    [Space]
    [Header("FireEffect")]
    public GameObject fireEffect;
    public static GameObject FireEffect { get; set; }

    [Space]
    [Header("LaserBeamEffect")]
    public GameObject laserBeamEffect;
    public static GameObject LaserBeamEffect { get; set; }

    [Space]
    [Header("DestroyObstacleEffect")]
    public GameObject destroyObstacleEffect;
    public static GameObject DestroyObstacleEffect { get; set; }

    [Space]
    [Header("BulletHitEffect")]
    public GameObject bulletHitEffect;
    public static GameObject BulletHitEffect { get; set; }

    [Space]
    [Header("WeaponFireEffect")]
    public GameObject weaponFireEffect;
    public static GameObject WeaponFireEffect { get; set; }

    [Header("GraySmoke")]
    public GameObject graySmokeVFX;
    [Space]
    [Header("MassExplousion")]
    public GameObject massExplousionEffect;
    public static GameObject MassExpEffect { get; set; }
    [Space]
    [Header("MassDestroy")]
    public GameObject massDestroyEffect;
    public static GameObject MassDestroyEffect { get; set; }
    public static GameObject GraySmokeEffect { get; set; }

    public static GameObject Init(GameObject obj, Vector3 pos, out GameObject particle)
    {
        GameObject part = Instantiate(obj, pos, Quaternion.identity);
        particle = part;
        return particle;
    }

    private void Awake()
    {
        RockParticle = rocksParticke;
        ShootEffect = shootEffect;
        FireEffect = fireEffect;
        LaserBeamEffect = laserBeamEffect;
        DestroyObstacleEffect = destroyObstacleEffect;
        BulletHitEffect = bulletHitEffect;
        WeaponFireEffect = weaponFireEffect;
        GraySmokeEffect = graySmokeVFX;
        MassDestroyEffect = massDestroyEffect;
        MassExpEffect = massExplousionEffect;
    }

}
public static class InitParticle
{
    public static GameObject InitRockParticle(Vector3 pos, out GameObject readyParticle)
    {
        ParticleHolder.Init(ParticleHolder.RockParticle, pos, out GameObject newPart);
        readyParticle = newPart;
        return readyParticle;
    }
    public static GameObject InitShootEffect(Vector3 pos, out GameObject readyParticle)
    {
        ParticleHolder.Init(ParticleHolder.ShootEffect, pos, out GameObject newPart);
        readyParticle = newPart;
        return readyParticle;

    }
    public static void InitFireEffect(Vector3 pos, GameObject obj)
    {
        ParticleHolder.Init(ParticleHolder.FireEffect, pos, out obj);
    }
    public static GameObject InitLaserBeamEffect(Vector3 pos, out GameObject readyParticle)
    {
        ParticleHolder.Init(ParticleHolder.LaserBeamEffect, pos, out GameObject newPart);
        readyParticle = newPart;
        return readyParticle;
    }
    public static GameObject InitDestroyObstacleEffect(Vector3 pos, out GameObject readyParticle)
    {
        ParticleHolder.Init(ParticleHolder.DestroyObstacleEffect, pos, out GameObject newPart);
        readyParticle = newPart;
        return readyParticle;
    }
    public static GameObject InitDestroyBulletHitEffect(Vector3 pos, out GameObject readyParticle)
    {
        ParticleHolder.Init(ParticleHolder.BulletHitEffect, pos, out GameObject newPart);
        readyParticle = newPart;
        return readyParticle;
    }
    public static GameObject InitWeaponFireEffect(Vector3 pos, out GameObject readyParticle)
    {
        ParticleHolder.Init(ParticleHolder.WeaponFireEffect, pos, out GameObject newPart);
        readyParticle = newPart;
        return readyParticle;
    }
    public static GameObject InitGraySmokeVFX(Vector3 pos, out GameObject readyParticle)
    {
        ParticleHolder.Init(ParticleHolder.GraySmokeEffect, pos, out GameObject newPart);
        readyParticle = newPart;
        return readyParticle;
    }

    public static GameObject InitMassExplousion(Vector3 pos, out GameObject readyParticle)
    {
        ParticleHolder.Init(ParticleHolder.MassExpEffect, pos, out GameObject newPart);
        readyParticle = newPart;
        return readyParticle;
    }
    public static GameObject InitMassDestroy(Vector3 pos, out GameObject readyParticle)
    {
        ParticleHolder.Init(ParticleHolder.MassDestroyEffect, pos, out GameObject newPart);
        readyParticle = newPart;
        return readyParticle;
    }
}
