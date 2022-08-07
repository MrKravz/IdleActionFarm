using Assets.Scripts.PlayerScripts.PlayerComponents;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UpdateMoneyInfoManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private MoneyComponent _currentMoney;

        public void UpdateInfo()
        {
            text.text = _currentMoney.CurrentValue.ToString(); 
        }
    }
}