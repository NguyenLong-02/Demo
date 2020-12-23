using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Michsky.UI.ModernUIPack
{
    public class ProgressBar : MonoBehaviour
    {
        [Header("OBJECTS")]
        public Transform loadingBar;
        public Transform textPercent;
        public Slider Healbarslider;

        [Header("VARIABLES (IN-GAME)")]
        public bool isOn;
        [Range(0, 100)] public float currentPercent;

        [Header("SPECIFIED PERCENT")]
        public bool enableSpecified;
        [Range(0, 100)] public float specifiedValue;

        private void Start()
        {
            currentPercent = 100f;
        }

        void Update()
        {
            if (currentPercent <= 100 && isOn == true && enableSpecified == false)


            if (currentPercent <= 100 && isOn == true && enableSpecified == true)
            {
                if (currentPercent <= specifiedValue) { }
            }

            if (enableSpecified == true && specifiedValue == 0)
                currentPercent = 0;

            loadingBar.GetComponent<Image>().fillAmount = currentPercent / 100;
            textPercent.GetComponent<TextMeshProUGUI>().text = ((int)currentPercent).ToString() + "%";
            Healbarslider.normalizedValue = currentPercent / 100;
        }
    }
}