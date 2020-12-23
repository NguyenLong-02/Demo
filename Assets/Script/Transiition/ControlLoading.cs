using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Assets.Script.Transition
{
    public class ControlLoading : MonoBehaviour
    {
        public Slider slider;
        public Text text;
        private bool isNewgame;

        public static ControlLoading Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void Setisreturn(bool check)
        {
            isNewgame = check;
        }
        public bool ReturnisNewgame()
        {
            return isNewgame;
        }

        private void Start()
        {
            slider = GetComponent<Slider>();
        }



        public void Loadbar(int index)
        {
            StartCoroutine(StartLoadingBar(index));

        }


        IEnumerator StartLoadingBar(int index)
        {
            yield return new WaitForSeconds(2f);
            AsyncOperation operation = SceneManager.LoadSceneAsync(index);
            while (operation.isDone == false)
            {
                float progess = Mathf.Clamp01(operation.progress / 0.9f); //
                slider.value = progess;
                text.text = progess * 100f + "%";
                yield return null;
            }
        }
    }
}
