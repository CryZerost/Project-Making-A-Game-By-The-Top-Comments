using UnityEngine;

public class Dummy : MonoBehaviour, IDamage
{
    [SerializeField] private float health = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (health <= 0)
        {
           this.gameObject.SetActive(false);
            Debug.Log($"-{damage}");
        }
        else
        {
            health -= damage;
        }




    }
}
