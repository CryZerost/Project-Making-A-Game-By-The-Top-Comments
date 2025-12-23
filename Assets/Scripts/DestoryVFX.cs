using UnityEngine;
using UnityEngine.VFX;

public class DestroyVFX : MonoBehaviour
{
    private VisualEffect vfx;

    private void Awake()
    {
        vfx = GetComponent<VisualEffect>();
    }

    private void Update()
    {
        if (vfx == null) return;

        if (vfx.aliveParticleCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
