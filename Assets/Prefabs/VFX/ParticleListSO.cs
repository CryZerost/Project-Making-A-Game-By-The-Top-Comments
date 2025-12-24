using UnityEngine;

[CreateAssetMenu(fileName = "particleSO", menuName = "effect/particleSO")]
public class ParticleListSO : ScriptableObject
{
    public ParticleSystem[] _particleSystemList;
}
