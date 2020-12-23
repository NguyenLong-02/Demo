using Assets.Script.Material_And_Food.Base;
using Assets.Script.Play_Game;
using Assets.Script.Store_Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Material_And_Food
{
    public class Rock : MonoBehaviour, IMaterial
    {
        [Header("GAMEOBJECT")]
        [SerializeField] private TextMeshProUGUI Notifi_Discription;
        [SerializeField] private Rigidbody Character;
        [SerializeField] private GameObject Request;
        [SerializeField] private TextMeshProUGUI TitleRequest;
        [SerializeField] private TextMeshProUGUI Discription;
        [SerializeField] private Button Go_Get;
        [SerializeField] private Button GetMaterial;
        [SerializeField] private GetMaterial GetMaterial_button_enable;

        [Header("Tree Detail")]
        public int materials = 30;
        public float lifetime = 20;
        private readonly float speed = 8f;

        [SerializeField] private bool isOpenRequest = false;
        [SerializeField] private bool isGoGet = false;
        [Header("Return This Transform")]
        private Transform thistranform; // Chứa các transform của Object đã gán với class này (Khác nhau)

        private void Start()
        {
            lifetime = 20f;
            thistranform = this.transform; // Thực hiện việc gán thistranform này bằng với transform mà object đang sở hữu
            Request.SetActive(false);

        }

        void FixedUpdate()
        {
            Vector3 direction = transform.position - Character.position;
            if (Distance() > 1 && isGoGet == true)
            {
                Character.AddForce(direction * speed * 100 * Time.fixedDeltaTime);
            }

            if (Distance() <= 10)
            {
                lifetime -= Time.deltaTime;
            }

            if (lifetime <= 0)
            {
                lifetime = 20f;
                Resousce.Instance.rocks += materials;
                Resousce.Instance.twigs += Random.Range(0, 20);
                Resousce.Instance.small_stone += Random.Range(0, 20);

                GetMaterial_button_enable.isProcess = false;
                Destroy(gameObject);
            }
        }



        public void Get_Button_Down() // Dùng để mở bảng thu hoacwjh khi ta ấn nút của những lệnh trong GetMaterial
        {
            isOpenRequest = !isOpenRequest;
            Request.SetActive(isOpenRequest);

            Go_Get.onClick.RemoveAllListeners();
            Go_Get.onClick.AddListener(this.Get_Mat);


            TitleRequest.text = "MINING ROCK";
            Discription.text = $"Distance to the point : {Distance()} \n Time to the point {Timer()} \n " +
                                $"Rock : {materials} \n Time to mine rocks : {lifetime}";
        }



        public Transform Get_Transform()
        {
            return thistranform; // Thực hiện việc lấy các Transform của các object đã gán với Class này
        }


        public void Get_Mat() // Dùng để tiến tới thu hoặch
        {
            isGoGet = true;
            GetMaterial_button_enable.isProcess = true;
            Notifi_Discription.text = "IS MINING ROCKS";
            Request.SetActive(false);
            GetMaterial_button_enable.list_button_enable.ForEach((but) => Destroy(but));
            GetMaterial_button_enable.list_button_enable.Clear();
            GetMaterial.interactable = true;

        }

        public float Timer()
        {
            return (Distance() / 150 / speed * 600 * Time.fixedDeltaTime);
        }

        public float Distance()
        {
            return Vector3.Distance(Character.transform.position, transform.position);
        }
    }
}
