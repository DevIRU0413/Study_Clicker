using System;
using UnityEngine;

namespace GoldMetal_Jelly
{
    // 재화 매니저
    public class CurrencyManager : MonoBehaviour
    {
        public static CurrencyManager Instance;

        public int Gold { get; private set; }
        public int Gelatin { get; private set; }

        public Action OnCurrencyChanged;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            Load();
        }

        void Load()
        {
            Gold = PlayerPrefs.GetInt(PrefKeys.Gold, 100);
            Gelatin = PlayerPrefs.GetInt(PrefKeys.Gelatin, 200);
        }

        void Save()
        {
            PlayerPrefs.SetInt(PrefKeys.Gold, Gold);
            PlayerPrefs.SetInt(PrefKeys.Gelatin, Gelatin);
            PlayerPrefs.Save();
        }

        public void AddGold(int amount)
        {
            Gold += amount;
            Save();
            OnCurrencyChanged?.Invoke();
        }

        public void AddGelatin(int amount)
        {
            Gelatin += amount;
            Save();
            OnCurrencyChanged?.Invoke();
        }

        public bool SpendGold(int amount)
        {
            if (Gold < amount)
                return false;

            Gold -= amount;
            Save();
            OnCurrencyChanged?.Invoke();
            return true;
        }

        public bool SpendGelatin(int amount)
        {
            if (Gelatin < amount)
                return false;

            Gelatin -= amount;
            Save();
            OnCurrencyChanged?.Invoke();
            return true;
        }
    }
}
