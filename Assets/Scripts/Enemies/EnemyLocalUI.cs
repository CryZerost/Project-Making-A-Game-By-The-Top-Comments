using UnityEngine;
using UnityEngine.UI;

public class EnemyLocalUI : MonoBehaviour
{
    public Slider enemyHealthSlider;
    public Transform healthTransform;

    public void Update()
    {
       healthTransform.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
    
    public void UpdateHealthUI(float health, float maxHealth)
    {
        healthTransform.gameObject.SetActive(true);
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = Mathf.Clamp(health, 0, maxHealth);
    }

}
