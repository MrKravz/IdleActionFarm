using Assets.Scripts.PlayerScripts.PlayerComponents;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CuttingWheatManager : MonoBehaviour
    {
        [SerializeField] private WheatGrowingManager _wheat;
        [SerializeField] private WheatComponent _wheatComponent;

        public void PickupHay(int value)
        {
            _wheatComponent.Add(value);
        }
    }
}