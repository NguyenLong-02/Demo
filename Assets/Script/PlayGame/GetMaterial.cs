using Assets.Script.Store_Data;
using UnityEngine;
using System.Collections.Generic;
using Assets.Script.Material_And_Food.Base;
using Assets.Script.Material_And_Food;
using UnityEngine.UI;
using TMPro;

namespace Assets.Script.Play_Game
{
    public class GetMaterial : MonoBehaviour
    {
        [Header("Checking is Process or Not")]
        public bool isProcess;

        [Header("LIST OF GET MATERIAL")]
        [SerializeField] private List<IAnimal> _animal = new List<IAnimal>(); // Dùng List chứa các Interface để đảm bảo tính 1 - nhiều
        [SerializeField] private List<IMaterial> _material = new List<IMaterial>();

        [Header("GAME OBJECT")]
        [SerializeField] private GameObject Button_Chop_Prefabs; // Chứa button để thực hiện việc chặt
        [SerializeField] private GameObject Button_Mine_Prefabs;
        [SerializeField] private GameObject Button_Hunt_Prefabs;

        [SerializeField] private Resousce res;
        [SerializeField] private GameObject Request;
        [SerializeField] private Animator Notifi;

        [SerializeField] private Button Get_Material; // Mỗi lần Bật Pannel lên thì Set Interacable của Button GetMaterial thành false


        [Header("LIST BUTTON AVAILABLE")]
        public List<GameObject> list_button_enable = new List<GameObject>(); // Lưu trữ những button đang hiện hữu

        [Header("LIST FOR CHECKING MATERIAL")]
        public List<int> list_check_material = new List<int>(); // Check những tài nguyên đã tồn tại cho việc gán nó với button
        public List<int> list_check_animal = new List<int>(); // Check những cái vật đã tồn tại cho việc gán nó với button

        [Header("MAX OBJECT OF BUTTON")]
        [SerializeField] private int MaxFind = 10;
        public List<IMaterial> Getmaterial()
        {
            return _material;
        }

        public List<IAnimal> Getanimal()
        {
            return _animal;
        }


        #region Get Material And Food

            #region Chopping Tree
        public void Chop()
        {
            if(!isProcess)
            {
                Get_Material.interactable = true;
                Request.SetActive(false);
                _material.Clear(); // Thực hiện việc tái tạo lại List giữ tài nguyên
                list_check_material.Clear(); // Tương tự với việc tái tạo lại list để check để tránh các trường hợp trùng nhau

                if (list_button_enable.Count > 0) // Check xem thử trong  list_button_enable có phần tử nào không, nếu có thì Destroy và tái tạo mới
                {
                    list_button_enable.ForEach((button) => Destroy(button)); // Mỗi lần ấn một nút mới là nút cũ phải Destroy
                    list_button_enable.Clear(); // Sau khi Destroy xong thì khởi tạo lại list để chứa các Button Object khác để tiết kiệm bộ nhớ
                }


                /*            res.list_trees.ForEach((tree) => _material.Add(tree));*/ // Có thể dùng cách này để thêm 

                foreach (ATree tree in res.list_trees)
                {
                    if (tree is IMaterial trees) _material.Add(trees);
                }

                for (int i = 0; i < MaxFind; i++)
                {
                    // Ở đây ta sẽ thực hiện việc hiện nút một cách ngẫu nhiên dựa theo số lượng các Obejct cây có trong scene
                    // random trúng số nào thì cây tại vị trí số đó sẽ được gán dính với Button bằng cách dùng lệnh Íntantiate
                    // bên dưới
                    var random = Random.Range(0, _material.Count);

                    // Sau khi random ta thực hiện việc kiểm tra liệu số random tượng chưng cho vị trí của cây trong _animal
                    // đã tồn tại các số này chưa tức là kiểm tra cây đó đã có gán dính button hay chưa bằng việc check vị trí
                    // của cây trong một List khác ở đây là list_check_trees, list_check_trees ở đây có nhiệm vụ là giữ những
                    // vị trí của những cây đã gán với button rồi. Vậy nên lúc random ta kiểm tra xem thử cái số random này nó
                    // có tồn tại trong list_check_trees hay không nếu không thì thêm(Add) còn ko thì return.
                    if (list_check_material.Contains(random)) return;
                    else list_check_material.Add(random);

                    // Ở đây chúng ta thực hiện việc tạo Button Prefabs gắn liền với các Object dựa vào
                    // Transform, position, rotation đã nhập vào
                    if (_material[random].Get_Transform() != null)
                    {
                        GameObject buttonclone = Instantiate(Button_Chop_Prefabs, // Object Clone
                        _material[random].Get_Transform().position, // Tại một Position theo Cái Material có trong List ở đây là các Trees
                        Button_Chop_Prefabs.transform.rotation, // Tạo một clone theo Roration của ButtonPrefabs
                        _material[random].Get_Transform()); // Transform này sẽ đc tạo những Button là Object con của Trasform ở ngoài Hierarchy

                        buttonclone.GetComponent<IndexButton>().index = random; // Thực hiện việc lưu vị trí của những Material Trên Button Clone
                                                                                // Để chúng ta có thể dùng vị trí này để lấy những class Material ra để sử dụng (Ở đây mục đích chính là gọi các lệnh 
                                                                                // Khi chúng ta ấn vào nút của Button Clone và Button thì cần Có lệnh OnClick Tham chiếu đến một funcion nào đó mới thực hiện được
                                                                                // Ở đây là lệnh trong các class Material.


                        list_button_enable.Add(buttonclone); // Tiến hành việc thêm các button hiện hữu vào trong list list_button_trees

                        // Kiểm tra khoảng cách
                        for (int j = 0; j <= 1; j++)
                        {
                            float distance = Vector3.Distance(buttonclone.transform.position,
                                                _material[random].Get_Transform().position); // Tính khoảng cách từ Nút tới cây
                            if (distance < 5f)  // Nếu nhỏ hơn 5f
                            {
                                // Thì chúng ta tiến hành việc tăng chiều cao Y lên thêm 1.8 lần, X và Z vẫn giữ nguyên
                                buttonclone.transform.position = new Vector3(_material[random].Get_Transform().position.x,
                                _material[random].Get_Transform().position.y * 1.8f,
                                _material[random].Get_Transform().position.z);
                            }
                        }
                    }
                }

            }else
            {
                Notifi.Play("In");
            }
            
        }
        #endregion

            #region Mining Rock And Gold
        public void Mine()
        {
            if (!isProcess)
            {
                Get_Material.interactable = true;
                Request.SetActive(false);
                _material.Clear(); // Thực hiện việc tái tạo lại List giữ tài nguyên
                list_check_material.Clear(); // Tương tự với việc tái tạo lại list để check để tránh các trường hợp trùng nhau

                if (list_button_enable.Count > 0) // Check xem thử trong  list_button_enable có phần tử nào không, nếu có thì Destroy và tái tạo mới
                {
                    list_button_enable.ForEach((button) => Destroy(button)); // Mỗi lần ấn một nút mới là nút cũ phải Destroy
                    list_button_enable.Clear(); // Sau khi Destroy xong thì khởi tạo lại list để chứa các Button Object khác để tiết kiệm bộ nhớ
                }

                /*            res.list_rocks.ForEach((rock) => _material.Add(rock));*/ // Có thể dùng cách này để thêm 
                foreach (Rock rock in res.list_rocks)
                {
                    if (rock is IMaterial rocks) _material.Add(rocks);
                }
                for (int i = 0; i < MaxFind; i++)
                {
                    var random = Random.Range(0, _material.Count);

                    if (list_check_material.Contains(random)) return;
                    else list_check_material.Add(random);


                    if (_material[random].Get_Transform() != null)
                    {
                        // Ở đây chúng ta thực hiện việc tạo Button Prefabs gắn liền với các Object dựa vào
                        // Transform, position, rotation đã nhập vào
                        GameObject buttonclone = Instantiate(Button_Mine_Prefabs, // Object Clone
                            _material[random].Get_Transform().position, // Tại một Position theo Cái Material có trong List ở đây là các Trees
                            Button_Mine_Prefabs.transform.rotation); // Tạo một clone theo Roration của ButtonPrefabs

                        buttonclone.GetComponent<IndexButton>().index = random; // Thực hiện việc lưu vị trí của những Material Trên Button Clone
                                                                                // Để chúng ta có thể dùng vị trí này để lấy những class Material ra để sử dụng (Ở đây mục đích chính là gọi các lệnh 
                                                                                // Khi chúng ta ấn vào nút của Button Clone và Button thì cần Có lệnh OnClick Tham chiếu đến một funcion nào đó mới thực hiện được
                                                                                // Ở đây là lệnh trong các class Material.

                        list_button_enable.Add(buttonclone); // Tiến hành việc thêm các button hiện hữu vào trong list list_button_trees

                        // Kiểm tra khoảng cách
                        for (int j = 0; j <= 1; j++)
                        {
                            float distance = Vector3.Distance(buttonclone.transform.position,
                                                _material[random].Get_Transform().position); // Tính khoảng cách từ Nút tới cây
                            if (distance < 5f)  // Nếu nhỏ hơn 5f
                            {
                                // Thì chúng ta tiến hành việc tăng chiều cao Y lên thêm 1.8 lần, X và Z vẫn giữ nguyên
                                buttonclone.transform.position = new Vector3(_material[random].Get_Transform().position.x,
                                _material[random].Get_Transform().position.y * 1.8f,
                                _material[random].Get_Transform().position.z);
                            }
                        }
                    }
                }
            }else
            {
                Notifi.Play("In");
            }
        }
        #endregion

            #region Hungting Animal For Food
        public void Hunt()
        {
            if(!isProcess)
            {
                Get_Material.interactable = true;
                Request.SetActive(false);
                _animal.Clear(); // Thực hiện việc tái tạo lại List giữ tài nguyên
                list_check_animal.Clear(); // Tương tự với việc tái tạo lại list để check để tránh các trường hợp trùng nhau

                if (list_button_enable.Count > 0) // Check xem thử trong  list_button_enable có phần tử nào không, nếu có thì Destroy và tái tạo mới
                {
                    list_button_enable.ForEach((button) => Destroy(button)); // Mỗi lần ấn một nút mới là nút cũ phải Destroy
                    list_button_enable.Clear(); // Sau khi Destroy xong thì khởi tạo lại list để chứa các Button Object khác để tiết kiệm bộ nhớ
                }
                /*            res.list_animals.ForEach((animal) => _material.Add(animal));*/ // Có thể dùng cách này để thêm 
                foreach (Animal animal in res.list_animals)
                {
                    if (animal is IAnimal animals) _animal.Add(animals);
                }
                if (_animal.Count > 0)
                {
                    for (int i = 0; i < MaxFind; i++)
                    {
                        var random = Random.Range(0, _animal.Count);

                        if (list_check_animal.Contains(random)) return;
                        else list_check_animal.Add(random);


                        if (_animal[random].Get_Transform() != null)
                        {
                            GameObject buttonclone = Instantiate(Button_Hunt_Prefabs, // Object Clone
                            _animal[random].Get_Transform().position, // Tại một Position theo Cái Material có trong List ở đây là các Trees
                            Button_Hunt_Prefabs.transform.rotation, // Tạo một clone theo Roration của ButtonPrefabs
                            _animal[random].Get_Transform()); // Transform này sẽ đc tạo những Button là Object con của Trasform ở ngoài Hierarchy

                            buttonclone.GetComponent<IndexButton>().index = random; // Thực hiện việc lưu vị trí của những Animal Trên Button Clone
                                                                                    // Để chúng ta có thể dùng vị trí này để lấy những class Animal ra để sử dụng (Ở đây mục đích chính là gọi các lệnh 
                                                                                    // Khi chúng ta ấn vào nút của Button Clone và Button thì cần Có lệnh OnClick Tham chiếu đến một funcion nào đó mới thực hiện được
                                                                                    // Ở đây là lệnh trong các class Animal.

                            list_button_enable.Add(buttonclone);

                            for (int j = 0; j <= 1; j++)
                            {
                                float distance = Vector3.Distance(buttonclone.transform.position,
                                                    _animal[random].Get_Transform().position); // Tính khoảng cách từ Nút tới cây
                                if (distance < 5f)  // Nếu nhỏ hơn 5f
                                {
                                    // Thì chúng ta tiến hành việc tăng chiều cao Y lên thêm 1.8 lần, X và Z vẫn giữ nguyên
                                    buttonclone.transform.position = new Vector3(_animal[random].Get_Transform().position.x,
                                    _animal[random].Get_Transform().position.y * 1.8f,
                                    _animal[random].Get_Transform().position.z);
                                }
                            }
                        }

                    }
                }
            }else
            {
                Notifi.Play("In");
            }
        }
        #endregion

        #endregion

    }
}
