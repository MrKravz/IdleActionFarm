using Assets.Scripts.Managers;
using UnityEngine;

public class PlayerBarnCollide : MonoBehaviour
{
    [SerializeField] private SellManager _sellManager;

    private void OnTriggerEnter(Collider other)
    {
        _sellManager.SellAllWheat();
    }
}
