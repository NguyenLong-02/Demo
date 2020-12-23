using Assets.Script.Transition;
using System;
using UnityEngine;

namespace Assets.Script.Menu_Start_Game
{
    public class MenuGame : MonoBehaviour
    {
        #region Button Animation
        [Header("Button Animation")]
        [SerializeField] private Animator NewMove;
        [SerializeField] private Animator CreMove;
        [SerializeField] private Animator OptionMove;
        #endregion

        #region Object Windown
        [Header("Button Menu")]
        [SerializeField] private GameObject OptionMenu;
        [SerializeField] private GameObject Credit;
        #endregion

        #region Windown Pannel Animation 
        [Header("Windown Pannel")]
        [SerializeField] private Animator Option;
        [SerializeField] private Animator Cre;
        #endregion

        private bool isLoad = false;
        private bool isCredit = false;
        private bool isOption = false;

        private void Update()
        {
            Option.SetBool("On", isOption);
            Cre.SetBool("On", isCredit);
        }


        #region Control Windown Pannel

        public void TurnOnOffOption()
        {
            if (isLoad) isLoad = false;
            if (isCredit) isCredit = false;
            isOption = !isOption;
        }

        public void TurnOnOffCredit()
        {
            if (isLoad) isLoad = false;
            if (isOption) isOption = false;
            isCredit = !isCredit;
        }
        #endregion

        #region Button Menu (NEW GAME AND QUIT)
        public void GameStart()
        {
            EndTransition.Instance.TriggerAnimation();
            ControlLoading.Instance.Loadbar(1);
        }

        public void Quit()
        {
            Application.Quit();
        }

        #endregion

        #region Button Trigger
        public void TriggerNewMove(bool check)
        {
            NewMove.SetBool("On", check);
        }


        public void TriggerOption(bool check)
        {
            CreMove.SetBool("On", check);
        }

        public void TriggerQuit(bool check)
        {
            OptionMove.SetBool("On", check);
        }
        #endregion
    }
}
