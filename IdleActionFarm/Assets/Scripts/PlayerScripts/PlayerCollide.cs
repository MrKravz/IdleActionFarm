using Assets.Scripts.GameplayManagers;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerCollide : MonoBehaviour
    {
        [SerializeField] private Manager _manager;
       // [SerializeField] private Animator _animator;

        private void OnTriggerEnter(Collider other)
        {
            var a = other.gameObject.GetComponent<Rigidbody>();
            //a.constraints = RigidbodyConstraints.FreezeAll;
            //_animator.SetBool("IsInAction", true);
            //_animator.
            _manager.PerformManagedOperation();
        }
    }
}