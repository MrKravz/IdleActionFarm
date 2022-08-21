using Assets.Scripts.Managers;
using UnityEngine;

public class PlayerHayCollide : MonoBehaviour
{
    [SerializeField] private CollectingWheatManager _collectingWheatManager;

    private void OnTriggerEnter(Collider other)
    {
        _collectingWheatManager.PickupHay(1);
    }
}
