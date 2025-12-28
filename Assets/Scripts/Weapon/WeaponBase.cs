using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private float _rangeDistance = 75f;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _weaponDamage;
    [SerializeField] private ParticleSystem _muzzleEffect;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private GameObject _hitMark;

    // Cooldown
    [SerializeField] private bool _canShoot = true;
    [SerializeField] private float _fireRate;

    private void OnEnable()
    {
        _muzzleEffect.Stop();
        _canShoot = true;
    }

    public void Shoot()
    {
        if (!_canShoot) return;
        StartCoroutine(ShootCooldown());
    }

    IEnumerator ShootCooldown()
    {
        _canShoot = false;
        ShootProjectile();

        float cooldown = 1f / _fireRate;
        yield return new WaitForSeconds(cooldown);

        _canShoot = true;
    }

    public void ShootProjectile()
    {
        _muzzleEffect.Play();

        RaycastHit hit;
        Ray ray = new Ray(_playerCamera.position, _playerCamera.forward);
        if (Physics.Raycast(ray, out hit, _rangeDistance))
        {
            Debug.Log(hit.transform.name);

            if (hit.collider.gameObject.TryGetComponent(out IDamage damage))
            {
                damage.TakeDamage(_weaponDamage);
            }
            else
            {
                Debug.Log("This object can't took any damage!");
            }

            GameObject impactObj = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            Destroy(impactObj, 1f);
        }

        if (Physics.Raycast(ray, out hit, float.PositiveInfinity))
        {
            if (hit.collider.gameObject.CompareTag("Enemy") || hit.collider.gameObject.CompareTag("Projectile")) return; 
            Instantiate(_hitMark, hit.point + (hit.normal * .01f), Quaternion.FromToRotation(Vector3.up, hit.normal));
        }
    }
}
