using UnityEngine;

public class Glock17 : WeaponBase
{
    protected override void ShootSystem()
    {
        RaycastHit hit;
        Vector3 origin = _playerCamera.position;
        Vector3 direction = _playerCamera.forward;

        if (WeaponRaycast(origin, direction, out hit, _rangeDistance))
        {
            Debug.Log("This is "+hit.transform.name);

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

        if (WeaponRaycast(origin,direction, out hit, float.PositiveInfinity))
        {
            if (hit.collider.gameObject.CompareTag("Enemy") || hit.collider.gameObject.CompareTag("Projectile")) return;
            Instantiate(_hitMark, hit.point + (hit.normal * .01f), Quaternion.FromToRotation(Vector3.up, hit.normal));
        }
    }
}
