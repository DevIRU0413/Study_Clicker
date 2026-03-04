using TMPro;
using UnityEngine;

namespace Pixui
{

    public class InGame : MonoBehaviour
    {
        int myNum;
        public int rewardNum = 10;

        public GameObject box;
        public GameObject reward;
        public TextMeshProUGUI score;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Debug.Log("Hello World!!");
            score.text = $"{myNum}";
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Click()
        {
            // Debug.Log("Click!!");

            myNum++;
            score.text = $"{myNum}";
            Debug.Log("myNum: " + myNum);

            if (myNum == rewardNum)
            {
                reward.SetActive(true);
                box.SetActive(false);
            }
        }
    }
}