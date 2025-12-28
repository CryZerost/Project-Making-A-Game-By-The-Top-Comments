using UnityEngine;

public class EnemyAlien : EnemyBase
{

    public override void Attack()
    {

        if (!alreadyAttacked)
        {

            if (player.gameObject.TryGetComponent(out PlayerStats damage))
            {
                damage.TakeDamage(enemyDamage);
            }

            ///
            StartCoroutine(ResetAttack());
        }


    }
}
