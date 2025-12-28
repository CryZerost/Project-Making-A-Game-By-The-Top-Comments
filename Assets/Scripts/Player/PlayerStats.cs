using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    public float health = 20f;
    [SerializeField] public float maxHealth = 20f;
    [SerializeField] private Transform _playerSpawnPoint;

    private void Start()
    {
        PlayerUI.instance.UpdateHealthUI(health, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        PlayerUI.instance.UpdateHealthUI(health, maxHealth);

        if (health <= 0) RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        transform.position = _playerSpawnPoint.position;
        health = maxHealth;
        PlayerUI.instance.UpdateHealthUI(health, maxHealth);

    }
}
