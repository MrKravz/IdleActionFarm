using Assets.Scripts.PlayerScripts.PlayerComponents;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerModel : MonoBehaviour
    {
        [field: SerializeField] public MoneyComponent Money { get; private set; } = default;
        [field: SerializeField] public WheatComponent Wheat { get; private set; } = default;
    }
}