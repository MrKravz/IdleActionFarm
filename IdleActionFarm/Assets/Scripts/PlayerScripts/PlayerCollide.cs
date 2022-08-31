using Assets.Scripts.GameplayManagers;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerCollide : MonoBehaviour
    {
        [SerializeField] private Manager _manager;

        private void OnTriggerEnter(Collider other)
        {
            _manager.PerformManagedOperation();
        }
    }
}