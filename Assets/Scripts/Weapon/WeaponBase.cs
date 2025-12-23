using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private float _rangeDistance = 20f;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _weaponDamage;
    [SerializeField] private ParticleSystem _muzzleEffect;

    private void Awake()
    {
        _muzzleEffect.Stop();
    }

    public void Shoot()
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
        }



    }
}
