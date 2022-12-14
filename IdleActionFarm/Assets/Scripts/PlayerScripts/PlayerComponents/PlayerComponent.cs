using UnityEngine;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    public abstract class PlayerComponent : ScriptableObject
    {
        [field: SerializeField] public int CurrentValue { get; protected set; } = default;
        [field: SerializeField] public int MaxValue { get; private set; } = default;
    }
}