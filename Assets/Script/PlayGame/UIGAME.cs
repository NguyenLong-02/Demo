using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Script.Play_Game
{
    public class UIGAME : MonoBehaviour
    {
        [Header("Block RayCast UI // Interacable Off")]
        [SerializeField] private Button Setting_Button;


        [Header("GameUI")]
        [SerializeField] private GameObject CameView;
        [SerializeField] private GameObject HealBar;
        [SerializeField] private GameObject Setting;
        [SerializeField] private GameObject Chest;
        [SerializeField] private GameObject MoreCommand;
        [SerializeField] private GameObject Resouces;

        [Header("UISWindown")]
        [SerializeField] private GameObject SettingWindown;
        [SerializeField] private GameObject InventoryWindown;
        [SerializeField] private GameObject CommandWindown;
        [SerializeField] private GameObject OptionWindown;

        [Header("UIAnimation")]
        [SerializeField] private Animator Inventory;
        [SerializeField] private Animator Option;
        [SerializeField] private Animator Command;

        [Header("BlackTransition")]
        [SerializeField] private Animator anim;

        [Header("CamControl")]
        [SerializeField] private CameraMoving isPreview; // Bool check 
        [SerializeField] private GameObject WindownReview;
        [SerializeField] private CanvasGroup canvasGroup; // For Disable RayCast
        [SerializeField] private TextMeshProUGUI TitleText;
        [SerializeField] private TextMeshProUGUI DescriptionText;

        [Header("MainCam")]
        [SerializeField] private Camera MainCam;
        [SerializeField] private Camera CameTransFormAboe;



        Quaternion PreviousRotare;
        Vector3 PreviousPosition;

        [Header("Check Bool")]
        public bool CameraFormAbove = false;
        public bool IsOpenSetting = false;
        public bool IsOpenChest = false;
        public bool IsOpenCommandWindown = false;
        public bool IsOpenOptionWindown = false;


        void Start()
        {
            Resouces.SetActive(false);
            MoreCommand.SetActive(false);
            Chest.SetActive(false);
            CameView.SetActive(false);
            HealBar.SetActive(false);
            Setting.SetActive(false);

            CommandWindown.SetActive(false);
            WindownReview.SetActive(false);
            SettingWindown.SetActive(false);

            TitleText.text = "Lost in the Ghost Island";
            DescriptionText.text = "You got accident when having ship traveling vacation, find some way to make you survil and send the SOS";
        }

        // Update is called once per frame
        void Update()
        {
            #region TurnOnNewGameDictiption

            if (isPreview.isPreview == false)
            {
                WindownReview.SetActive(true);
                canvasGroup.blocksRaycasts = false;
            }

            #endregion
        }

        #region ChangeCameraView

        public void TurnOffGetMaterial()
        {
            MoreCommand.SetActive(!CameraFormAbove); // Thực hiện việc tắt Get_Material đi bởi vì 2 Lệnh này đang giao dùng chúng
        }// Một lệnh đó là ChangeCameraView ở dưới nên lúc thực hiện nút của CameraChange thì tắt nút của MoreCommand đi và ngược lại

        public void ChangeCameraView()
        {
            // Hoán đổi giá trị bool để thực hiện việc kiểm tra ở trong và ngoài Script 
            // Giá trị mặc định của CameraFormAbove là false vậy nên lúc gọi thì nó sẽ tự chuyển thành true và thực hiện những lệnh khác
            CameraFormAbove = !CameraFormAbove;
            if (CameraFormAbove) // Nếu CameraFormAbove là true thì
            {
                PreviousPosition = MainCam.transform.position;
                PreviousRotare = MainCam.transform.rotation; // Lúc bật thì chuyển sang 1 vị trí và độ xoay khác thì lúc bật lại vị trí cũ
                // Thì ta cần một biến để lưu giữ độ xoay này

                MainCam.transform.position = CameTransFormAboe.transform.position; // Tiếp tục chuyển vị trí cam lên trên
                MainCam.transform.rotation = CameTransFormAboe.transform.rotation; // Chuyển độ xoay xuống dưới
            }
            else
            {
                MainCam.transform.rotation = PreviousRotare; // Lúc tắt đi thì chuyển về độ xoay và vị trí cũ
                MainCam.transform.position = PreviousPosition;
            }
        }

        #endregion

        #region OpenChest
        public void OpenChest()
        {
            IsOpenChest = !IsOpenChest;
            if (IsOpenChest) Inventory.Play("InvenOpen");
            else Inventory.Play("InvenClose");
        }

        #endregion

        #region Open Command Windown
        public void OpenCommandWindown()
        {
            IsOpenCommandWindown = !IsOpenCommandWindown;
            if (IsOpenCommandWindown) Command.Play("CollapOut");
            else Command.Play("Collap");
            CommandWindown.SetActive(IsOpenCommandWindown);
        }
        #endregion

        #region Setting Menu


        public void OpenSettingMenu()
        {
            IsOpenSetting = !IsOpenSetting;
            SettingWindown.SetActive(IsOpenSetting);
            Resouces.SetActive(!IsOpenSetting);
            MoreCommand.SetActive(!IsOpenSetting);
            CameView.SetActive(!IsOpenSetting);
            Chest.SetActive(!IsOpenSetting);
            HealBar.SetActive(!IsOpenSetting);
        }

        // RETURN TO MAIN MENU

        public void MainMenu()
        {
            anim.Play("EndBlack");
            StartCoroutine(StartTrantision());
        }

        IEnumerator StartTrantision()
        {
            yield return new WaitForSeconds(1.1f);
            SceneManager.LoadScene(0);
        }


        // OPEN OPTION WINDOWN

        public void OpenOptionWindown()
        {
            IsOpenOptionWindown = !IsOpenOptionWindown;
            Option.SetBool("On", IsOpenOptionWindown);
            Setting_Button.interactable = !IsOpenOptionWindown;
        }

        #endregion
    }
}
