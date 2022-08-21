using Assets.Scripts.PlayerScripts.PlayerComponents;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIScripts
{
    public class UpdateWheatInfo : UpdateUiInfo
    {
        [SerializeField] private WheatComponent _currentComponentValue;
        [SerializeField] private Image image;

        public override void UpdateInfo()
        {
            _valueText.text = _currentComponentValue.CurrentValue.ToString() + "/" + _currentComponentValue.MaxValue.ToString();
            image.fillAmount = (float)_currentComponentValue.CurrentValue / _currentComponentValue.MaxValue;
        }
    }
}