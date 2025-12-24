using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] particleChildren;

    private void Awake()
    {
        
    }

    private void Start()
    {
        float maxLifetime = 0f;

        foreach (var ps in particleChildren)
        {
            if (ps == null) continue;

            ps.Play();
        }

        Destroy(gameObject, 1f);
    }
}
