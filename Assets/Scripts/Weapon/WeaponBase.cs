using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected Transform _playerCamera;
    [SerializeField] protected float _rangeDistance = 75f;
    [SerializeField] protected Transform _bulletSpawnPoint;
    [SerializeField] protected float _weaponDamage;
    [SerializeField] protected ParticleSystem _muzzleEffect;
    [SerializeField] protected GameObject _hitEffect;
    [SerializeField] protected GameObject _hitMark;

    // Cooldown
    [SerializeField] protected bool _canShoot = true;
    [SerializeField] protected float _fireRate;
    [SerializeField] private int ammo = 10;
    [SerializeField] protected int maxAmmo = 10;
    [SerializeField] protected bool _isReloading = false;
    [SerializeField] protected float _reloadCooldown;

    private void OnEnable()
    {
        _muzzleEffect.Stop();
        _canShoot = true;
        _isReloading = false;
        PlayerUI.instance.UpdateAmmoUI(ammo, maxAmmo);
    }

    protected bool WeaponRaycast(
    Vector3 origin,
    Vector3 direction,
    out RaycastHit hit,
    float range
)
    {
        int _hitMask = ~LayerMask.GetMask("whatIsPlayer"); // ini nanti buat biar ya itu lah ya biar ga apakali pelurunya
        return Physics.Raycast(origin, direction, out hit, range, _hitMask);
    }


    public void Shoot()
    {
        if (!_canShoot || _isReloading) return;
        if (ammo <= 0 && !_isReloading) StartCoroutine(Reloading());
        else StartCoroutine(ShootCooldown());
    }

    IEnumerator ShootCooldown()
    { 
        _canShoot = false;
        ShootProjectile();

        float cooldown = 1f / _fireRate;
        yield return new WaitForSeconds(cooldown);

        _canShoot = true;
    }

    public void ReloadAmmo()
    {
        if (_isReloading) return;
        StartCoroutine(Reloading());
    }

    IEnumerator Reloading()
    {
        _isReloading = true;

        PlayerUI.instance.UpdateReloadUI("Is Reloading");

        yield return new WaitForSeconds(_reloadCooldown);

        ammo = maxAmmo;
        PlayerUI.instance.UpdateAmmoUI(ammo, maxAmmo);

        _isReloading = false;
    }

    public void ShootProjectile()
    {
        _muzzleEffect.Play();
        
        // Ammo
        ammo--;
        PlayerUI.instance.UpdateAmmoUI(ammo, maxAmmo);
        ShootSystem();

    }

    protected abstract void ShootSystem();
}
