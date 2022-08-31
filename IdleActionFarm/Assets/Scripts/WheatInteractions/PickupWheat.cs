using Assets.Scripts.GameplayManagers;
using UnityEngine;

namespace Assets.Scripts.WheatInteractions
{
    public class PickupWheat : MonoBehaviour
    {
        [SerializeField] private CollectManager _collect;
        [SerializeField] private WheatGrowthManager _wheat;

        public void CollectCulture()
        {
            _wheat.ResetWheatProgress();
            _collect.PerformManagedOperation(); 
        }
    }
}