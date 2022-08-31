using Assets.Scripts.PlayerScripts.PlayerComponents;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UIScripts
{
    public class UpdateMoneyInfo : MonoBehaviour, IListener
    {
        [SerializeField] protected TMP_Text _valueText;
        [SerializeField] private MoneyComponent _currentComponentValue;

        public void UpdateInfo()
        {
            _valueText.text = _currentComponentValue.CurrentValue.ToString();
        }
    }
}