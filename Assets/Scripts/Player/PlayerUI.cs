using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;

    [Header("Health UI")]
    public Slider playerHealthSlider;
    public TMP_Text playerHealthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateHealthUI(float health, float maxHealth)
    {
        playerHealthText.text = $"Health: {health}/{maxHealth}";
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = Mathf.Clamp(health,0, maxHealth);
    }
}
