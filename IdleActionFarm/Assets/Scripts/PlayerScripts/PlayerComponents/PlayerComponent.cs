using UnityEngine;

namespace Assets.Scripts.PlayerScripts.PlayerComponents
{
    public class PlayerComponent : MonoBehaviour
    {
        [field: SerializeField] public int CurrentValue { get; protected set; } = default;
        [field: SerializeField] public int MaxValue { get; private set; } = default;

    }
}