using UnityEngine;

namespace Assets.Scripts.GameplayManagers
{
    public abstract class Manager : MonoBehaviour
    {
        public abstract void PerformManagedOperation();
    }
}