using UnityEngine;
using System.Collections;

namespace Michsky.UI.ModernUIPack
{
    public class ModalWindowManager : MonoBehaviour
    {
        [SerializeField] GameObject CameraViewButton;
        [SerializeField] GameObject HealBar;
        [SerializeField] GameObject Setting;
        [SerializeField] GameObject Chest;
        [SerializeField] GameObject Resouces;
        [SerializeField] GameObject MoreCommand;
        Animator mwAnimator;
        void Start()
        {
            mwAnimator = gameObject.GetComponent<Animator>();
        }

        public void CloseWindow()
        {
            mwAnimator.Play("Fade-out");
            StartCoroutine(TuroOnUI());
        }

        IEnumerator TuroOnUI()
        {
            yield return new WaitForSeconds(0.3f);
            Resouces.SetActive(true);
            MoreCommand.SetActive(true);
            CameraViewButton.SetActive(true);
            Setting.SetActive(true);
            HealBar.SetActive(true);
            Chest.SetActive(true);
        }
    }
}