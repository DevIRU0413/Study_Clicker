using TMPro;
using UnityEngine;
namespace GoldMetal_Jelly
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] TMP_Text goldText;
        [SerializeField] TMP_Text gelatinText;

        private void Start()
        {
            CurrencyManager.Instance.OnCurrencyChanged += Refresh;
            Refresh();
        }

        void Refresh()
        {
            goldText.text = CurrencyManager.Instance.Gold.ToString();
            gelatinText.text = CurrencyManager.Instance.Gelatin.ToString();
        }

        private void OnDestroy()
        {
            CurrencyManager.Instance.OnCurrencyChanged -= Refresh;
        }
    }
}