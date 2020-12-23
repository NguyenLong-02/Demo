using UnityEngine;
using UnityEngine.UI;
namespace Assets.Script.Play_Game
{
    public class MoreCommand : MonoBehaviour
    {
        [SerializeField] private GetMaterial getMaterial; // GetMaterial Ở đây có nhiệm vụ sẽ thực hiện việc Distroy các button
        // Bởi vì lúc chúng ta ấn tắt Get_Material thì các Button cx phải biến mất theo nên ta cần Destroy nó 
        // Chúng ta có thể thực hiện việc này thông qua việc đã tạo một List để chứa các Object Button ở trong class GetMaterial
        // Việc tiếp theo là chúng ta duyệt list đó và Destroy tất cả các Obejct nằm trong List thì khi đó Ngoài Scene cũng
        // sẽ mất các Object Button luôn

        [Header("Disable Enable Button Parrent")]
        [SerializeField] private Button MoreCommandButton; // Bật tắt Interacable của Button Parent để tránh việc đụng nhầm gây lỗi


        [Header("Command Windown Pannel")]
        [SerializeField] private GameObject GetMaterialWindown;
        [SerializeField] private GameObject CraftingWindown;
        [SerializeField] private GameObject QuestWindown;

        [SerializeField] private GameObject RequestWindown;

        [Header("Camera Control While Use Command")]
        [SerializeField] UIGAME ISCameraFormAbove;
        [SerializeField] GameObject CameraChange;

        [Header("Check is On or Off")]
        [SerializeField] private bool isMa = false;
        [SerializeField] private bool isCa = false;
        [SerializeField] private bool isQu = false;


        private void Update()
        {
            CraftingWindown.SetActive(isCa);
            GetMaterialWindown.SetActive(isMa);
            QuestWindown.SetActive(isQu);
        }

        public void OpenGetMaterial()
        {
            isMa = !isMa;
            if (isCa) isCa = !isCa;
            if (isQu) isQu = !isQu;
            RequestWindown.SetActive(false);
            CameraChange.SetActive(!isMa); // Mỗi lần chúng ta bật GetMaterial lên thì chúng ta Disbale Button CameraChange đi

            if(isMa == false)
            {
                getMaterial.list_button_enable.ForEach((obj) => Destroy(obj)); // Khi Tắt OpenGetMaterial Destroy Button hiện hữa trên scene
                getMaterial.list_button_enable.Clear(); // Sau Đó khởi tạo lại danh sách cho việc chứa các Button

                getMaterial.list_check_animal.Clear(); // Tương tự với việc khởi tạo lại list kiểm tra sự trùng lập cho các animal
                getMaterial.list_check_material.Clear();// Tương tự với việc khởi tạo lại list kiểm tra sự trùng lập cho các material
            }
            //  // Ở đây chúng ta bắt đầu việc thực hiện nếu Chúng ta tắt nút Get_Material thì bắt đầu Destroy hết các Button có sẵn

            ISCameraFormAbove.ChangeCameraView(); // Đây là lệnh chuyển hướng nhìn cả Camera

            MoreCommandButton.interactable = !isMa; // Lúc này chúng ta thực hiện việc tắt interacble của Button Parent đi theo điều kiện 
            // Các nút con có bật hay không

        }

        public void OpenCrafting()
        {
            isCa = !isCa;
            if (isQu) isQu = !isQu;
            MoreCommandButton.interactable = !isCa;// Lúc này chúng ta thực hiện việc tắt interacble của Button Parent đi theo điều kiện 
            // Các nút con có bật hay không
        }

        public void OpenQuestWindown()
        {
            isQu = !isQu;
            if (isCa) isCa = !isCa;
            MoreCommandButton.interactable = !isQu;// Lúc này chúng ta thực hiện việc tắt interacble của Button Parent đi theo điều kiện 
            // Các nút con có bật hay không
        }
    }
}
