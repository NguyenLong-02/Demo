using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Transition
{
    public class StartTransition : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            Invoke(nameof(Disable), 2f);
        }

        void Disable()
        {
            canvasGroup.blocksRaycasts = false;
        }
    }
}
