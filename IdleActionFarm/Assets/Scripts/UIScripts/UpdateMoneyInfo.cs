using Assets.Scripts.PlayerScripts.PlayerComponents;
using UnityEngine;

namespace Assets.Scripts.UIScripts
{
    public class UpdateMoneyInfo : UpdateUiInfo
    {
        [SerializeField] private MoneyComponent _currentComponentValue;

        public override void UpdateInfo()
        {
            _valueText.text = _currentComponentValue.CurrentValue.ToString();
        }
    }
}