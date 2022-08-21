using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerWheatCollide : MonoBehaviour
    {
        [SerializeField] private WheatGrowingManager _wheatGrowingManager;

        private void OnTriggerEnter(Collider other)
        {
            _wheatGrowingManager.CutWheat();
        }
    }
}