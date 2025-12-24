using UnityEngine;

public class Dummy : MonoBehaviour, IDamage
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private GameObject smokeEffectPrefabs;


    void OnEnable()
    {
        health = maxHealth;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(smokeEffectPrefabs, transform.position, transform.rotation);
           this.gameObject.SetActive(false);
            Debug.Log($"-{damage}");
        }

    }
}
