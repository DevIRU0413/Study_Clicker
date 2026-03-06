using UnityEngine;

namespace GoldMetal_Jelly
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameObject[] BorderList;
        public GameObject[] RespawnPointList;

        [Header("재화")]
        [SerializeField] private int _Jelatin;
        [SerializeField] private int _gold;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
    }
}