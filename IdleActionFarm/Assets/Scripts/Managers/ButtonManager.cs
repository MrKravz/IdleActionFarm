using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField] private Button _harvestButton;
        [SerializeField] private Button _sellButton;
        [SerializeField] private CuttingWheatManager _cuttingWheatManager;
        [SerializeField] private SellManager _sellManager;

        private void Awake()
        {
            _harvestButton.onClick.AddListener(() => _cuttingWheatManager.PickupHay());
            _sellButton.onClick.AddListener(() => _sellManager.SellWheat());
        }

        private void OnDestroy()
        {
            _harvestButton.onClick.RemoveAllListeners();
            _sellButton.onClick.RemoveAllListeners();
        }

    }
}