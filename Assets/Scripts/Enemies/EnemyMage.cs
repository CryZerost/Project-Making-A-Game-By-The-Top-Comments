using UnityEngine;

public class EnemyMage : EnemyBase
{
    [SerializeField] protected GameObject attackProjectile;
    [SerializeField] private Transform _projectileSpawnPoint;

    public override void Attack()
    {

        if (!alreadyAttacked)
        {
            ///Attack code here
            Vector3 spawnPos = _projectileSpawnPoint.position + transform.forward * 1.2f + Vector3.up * 0.25f;
            GameObject proj = Instantiate(attackProjectile, spawnPos, Quaternion.identity);

            Rigidbody rb = proj.GetComponent<Rigidbody>();
            Bullet bullet = rb.GetComponent<Bullet>();

            rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);

            ///
            StartCoroutine(ResetAttack());

            bullet.SetDamage(enemyDamage);
        }


    }
}
