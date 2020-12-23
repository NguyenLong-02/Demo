using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Transition
{
    public class EndTransition : MonoBehaviour
    {
        [SerializeField] private GameObject Im1;
        [SerializeField] private GameObject Im2;
        [SerializeField] private GameObject Im3;
        public static EndTransition Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Im1.SetActive(false);
            Im2.SetActive(false);
            Im3.SetActive(false);
        }

        public void TriggerAnimation()
        {
            Im1.SetActive(true);
            Im2.SetActive(true);
            Im3.SetActive(true);
        }
    }
}
