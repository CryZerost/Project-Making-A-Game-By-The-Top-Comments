using UnityEngine;
using UnityEngine.UI;

public class EnemyLocalUI : MonoBehaviour
{
    public Slider enemyHealthSlider;
    public Transform healthTransform;

    public float smoothSpeed = 20f;

    float targetHealth;


    void Update()
    {
        // Billboard ke camera
        healthTransform.rotation =
            Quaternion.LookRotation(healthTransform.position - Camera.main.transform.position);

        // Smooth value biar ga kaku amat
        enemyHealthSlider.value = Mathf.MoveTowards(
            enemyHealthSlider.value,
            targetHealth,
            smoothSpeed * Time.deltaTime
        );
    }

    public void UpdateHealthUI(float health, float maxHealth)
    {
        healthTransform.gameObject.SetActive(true);

        enemyHealthSlider.maxValue = maxHealth;
        targetHealth = Mathf.Clamp(health, 0, maxHealth);
    }

}
