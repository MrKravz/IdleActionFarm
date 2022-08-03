using Assets.Scripts.PlayerComponents;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UpdateMoneyInfoManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void UpdateInfo(MoneyComponent moneyComponent)
        {
            text.text = moneyComponent.CurrentValue.ToString(); 
        }
    }
}