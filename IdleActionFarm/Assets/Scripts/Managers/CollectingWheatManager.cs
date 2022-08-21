using Assets.Scripts.PlayerScripts.PlayerComponents;
using Assets.Scripts.UIScripts;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CollectingWheatManager : MonoBehaviour
    {
        [SerializeField] private WheatComponent _wheatComponent;
        [SerializeField] private UpdateUiInfo _updateInfoManager;

        public void PickupHay(int value)
        {
            _wheatComponent.Add(value);
            _updateInfoManager.UpdateInfo();
            //OnMoneyAdded?.Invoke(count);
            //Destroy(gameObject);
        }
    }
}