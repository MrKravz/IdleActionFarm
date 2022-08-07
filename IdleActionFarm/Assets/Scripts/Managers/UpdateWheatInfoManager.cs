using Assets.Scripts.PlayerScripts.PlayerComponents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    public class UpdateWheatInfoManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Image image;
        [SerializeField] private WheatComponent _currentWheat;

        public void UpdateInfo()
        {
            text.text = _currentWheat.CurrentValue.ToString() + "/" + _currentWheat.MaxValue.ToString();
            image.fillAmount = (float)_currentWheat.CurrentValue / _currentWheat.MaxValue;
           
        }
    }
}