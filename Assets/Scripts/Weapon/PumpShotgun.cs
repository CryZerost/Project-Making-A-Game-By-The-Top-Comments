using UnityEngine;

public class PumpShotgun : WeaponBase
{
    public int pelletCount = 10;
    public float spreadAngle = 6f;
    public float range = 50f;
    protected override void ShootSystem()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 forward = Camera.main.transform.forward;

        for (int i = 0; i < pelletCount; i++)
        {
            Vector3 direction = GetSpreadDirection(forward);
            RaycastHit hit;
            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray,out hit, _rangeDistance))
            {
                if (hit.collider.TryGetComponent(out IDamage damage))
                {
                    damage.TakeDamage(_weaponDamage);
                }

                Debug.DrawRay(origin, direction * hit.distance, Color.red, 1f);
            }

            GameObject impactObj = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            Destroy(impactObj, 1f);

            if (Physics.Raycast(ray, out hit, float.PositiveInfinity))
            {
                if (hit.collider.gameObject.CompareTag("Enemy") || hit.collider.gameObject.CompareTag("Projectile")) return;
                Instantiate(_hitMark, hit.point + (hit.normal * .01f), Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }

        Vector3 GetSpreadDirection(Vector3 forward)
        {
            float x = Random.Range(-spreadAngle, spreadAngle);
            float y = Random.Range(-spreadAngle, spreadAngle);

            return Quaternion.Euler(x, y, 0) * forward;
        }
    }

}
