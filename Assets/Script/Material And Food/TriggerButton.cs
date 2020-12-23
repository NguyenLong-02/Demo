using UnityEngine.UI;
using UnityEngine;
using Assets.Script.Store_Data;

public class TriggerButton : MonoBehaviour
{
    [SerializeField] private Button GetMaterial; // Mỗi lần Bật Pannel lên thì Set Interacable của Button GetMaterial thành false
    [SerializeField] private IndexButton index;
    [SerializeField] private Resousce res;
    [SerializeField] private TypeMat type;
    [SerializeField] private Button button; // Thực hiện việc Mở Request Pannel để tiến hành việc khai thác tài nguyên
    // Update is called once per frame
    private void Start()
    {
        GetMaterial = GameObject.FindGameObjectWithTag("Get").GetComponent<Button>();
        res = GameObject.FindGameObjectWithTag("Res").GetComponent<Resousce>();
        button = GetComponent<Button>();

        if(type == TypeMat.tree) // Nếu Type là tree thì thực hiện lệnh Get_Button_Down của class ATree
        {
            button.onClick.RemoveAllListeners(); // Xóa các Onlick có sẵn để tránh trường hợp bị lặp lại
            button.onClick.AddListener(ButtonDown_Tree); // sau đó thêm Lệnh vào trong OnClick
        }else if(type == TypeMat.rock) // Nếu Type là tree thì thực hiện lệnh Get_Button_Down của class Rock
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(ButtonDown_Rock);
        }
        else // Nếu Type là tree thì thực hiện lệnh Get_Button_Down của class Animal
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(ButtonDown_Animal);
        }

    }

    // Ở đây chúng ta không thể gán trực tiếp AddListener( res.list_trees[index.index].Get_Button_Down();   ) Như thế này được
    // Sẽ báo lỗi bởi vì AddListener chỉ nhận những lệnh Thuộc UnityAction hoặc những fucion có sẵn trong class chứa nó thì mới được

    // Vậy nên chúng ta thực hiện việc đưa res.list_trees[index.index].Get_Button_Down() là một Funcion nằm trong IAniaml Hay IMaterial
    // Đưa Funcion Get_Button_Down này cho Fucion trong class này thực hiện
    // Ở đây là ButtonDown_Tree, ButtonDown_Rock và ButtonDown_Animal sẽ thực hiện những lệnh nằm trong các class Atree, Rock và Animal
    // Như đã nói ở trên những lệnh nằm ngoài class thì Addlistener chỉ có thể thêm gián tiếp lệnh đó thông quá một fucion nằm trong class chứa
    // Lệnh Addlistener

    void ButtonDown_Tree()
    {
        GetMaterial.interactable = false;
        if (res.list_trees.Count > 0) res.list_trees[index.index].Get_Button_Down();   
    }
    void ButtonDown_Rock()
    {
        GetMaterial.interactable = false;
        if (res.list_rocks.Count > 0) res.list_rocks[index.index].Get_Button_Down();
    }
    void ButtonDown_Animal()
    {
        GetMaterial.interactable = false;
        if (res.list_animals.Count > 0) res.list_animals[index.index].Get_Button_Down();
    }
}

public enum TypeMat { tree, rock, animal} // Ở đây chúng ta phân loại ra 3 trường hợp để thực hiện việc Ấn Nút
