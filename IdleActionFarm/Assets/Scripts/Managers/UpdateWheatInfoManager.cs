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

        public void UpdateInfo(WheatComponent wheatComponent)
        {
            text.text = wheatComponent.CurrentValue.ToString() + "/" + wheatComponent.MaxValue.ToString();
            image.fillAmount = wheatComponent.CurrentValue / wheatComponent.MaxValue;
        }
    }
}