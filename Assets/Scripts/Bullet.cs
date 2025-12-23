using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private GameObject vfxHitPrefab;
    [SerializeField] private float _bulletLifetime = 3f;
    [SerializeField] private float _bulletDamage = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Destroy(gameObject, _bulletLifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contactPoint = collision.contacts[0];

        if (collision.gameObject.TryGetComponent(out IDamage damage))
        {
            damage.TakeDamage(_bulletDamage);
        }

        //if (vfxHitPrefab != null)
        //{
        //    Instantiate(vfxHitPrefab, contactPoint.point, Quaternion.LookRotation(contactPoint.normal));
        //}

        Destroy(gameObject);
    }
}
