using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;

    [Header("Health UI")]
    public Slider playerHealthSlider;
    public TMP_Text playerHealthText;

    [Header("Ammo UI")]
    public Slider ammoSlider;
    public TMP_Text ammoText;

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
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = Mathf.Clamp(health,0, maxHealth);
        playerHealthText.text = $"Health: {health}/{maxHealth}";
    }

    public void UpdateAmmoUI(float ammo, float maxAmmo)
    {
        ammoSlider.gameObject.SetActive(true);
        ammoSlider.maxValue = maxAmmo;
        ammoSlider.value = Mathf.Clamp(ammo, 0, maxAmmo);
        ammoText.text = $"Ammo: {ammo}/{maxAmmo}";

    }

    public  void UpdateReloadUI(string text)
    {
        ammoSlider.gameObject.SetActive(true);
        ammoText.text = $"{text}";
    }

    public void DisableAmmoUI()
    {
        ammoSlider.gameObject.SetActive(false);
    }
}
