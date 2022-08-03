using Assets.Scripts.PlayerScripts.PlayerComponents;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SellManager : MonoBehaviour
    {
        [SerializeField] private WheatComponent _wheatComponent;
        [SerializeField] private MoneyComponent _moneyComponent;
        [SerializeField] private int _priceOfHaystack;

        public void SellWheat()
        {
            _moneyComponent.Add(_wheatComponent.Reset() * _priceOfHaystack);
        }
    }
}