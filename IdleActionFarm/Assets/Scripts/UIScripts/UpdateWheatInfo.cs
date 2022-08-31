using Assets.Scripts.PlayerScripts.PlayerComponents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIScripts
{
    public class UpdateWheatInfo : MonoBehaviour, IListener
    {
        [SerializeField] protected TMP_Text _valueText;
        [SerializeField] private WheatComponent _currentComponentValue;
        [SerializeField] private Image image;

        public void UpdateInfo()
        {
            _valueText.text = _currentComponentValue.CurrentValue.ToString() + "/" + _currentComponentValue.MaxValue.ToString();
            image.fillAmount = (float)_currentComponentValue.CurrentValue / _currentComponentValue.MaxValue;
        }
    }
}