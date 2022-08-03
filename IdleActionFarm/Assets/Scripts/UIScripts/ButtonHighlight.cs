using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ButtonHighlight : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnTriggerEnter(Collider other)
        {
            _button.gameObject.SetActive(true);
        }
        private void OnTriggerExit(Collider other)
        {
            _button.gameObject.SetActive(false);
        }
    }
}
