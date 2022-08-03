using Assets.Scripts.PlayerComponents;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CuttingWheatManager : MonoBehaviour
    {
        [SerializeField] private WheatGrowingManager _wheat;
        [SerializeField] private WheatComponent _wheatComponent;

        public void PickupHay()
        {
            _wheatComponent.Add(1);
        }
    }
}