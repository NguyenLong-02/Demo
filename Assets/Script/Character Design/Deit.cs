using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Script.Transition;

namespace Assets.Script.Character_Design
{
    public class Deit : MonoBehaviour
    {
        private string Player_Name;
        private readonly List<char> Player_Name_Error = new List<char>()
        {'\\','*','-',',','_', '[',']','{','}','+','(',')','.','/','&','^','%','$','#','\'',',','\"',':',';','<','>','?','@'};
        private string skin_relation;

        [SerializeField] private TextMeshProUGUI skin_relation_text;
        [SerializeField] private TextMeshProUGUI Text_Name_Check;
        [SerializeField] private Material[] Current_Body = new Material[2];
        [SerializeField] private SkinnedMeshRenderer skinnedMesh;

        public static Deit Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            skin_relation = skin_relation_text.text;
            skinnedMesh.sharedMaterials = Current_Body;
        }

        public void Set_Body(int index, Material mat)
        {
            Current_Body[index] = mat;
        }

        // Cho bik Mauf Da
        public string GetSkin()
        {
            return skin_relation;
        }

        public void Set_PlayerName(string name)
        {
            if (name.Length > 5 && name.Length < 10)
            {
                Text_Name_Check.color = new Color(0, 0.490566f, 0.04017297f, 1);
                Text_Name_Check.text = "Name Is Valid";
                Player_Name = name;
            }
            else if (name.Length >= 10)
            {
                Text_Name_Check.color = Color.red;
                Text_Name_Check.text = "Name Too Long !!!";
            }
            else if (name.Length <= 5)
            {
                Text_Name_Check.text = "";
            }

            foreach (char index in name)
            {
                for (int i = 0; i < Player_Name_Error.Count; i++)
                {
                    if (index.Equals(Player_Name_Error[i]))
                    {
                        Text_Name_Check.color = Color.red;
                        Text_Name_Check.text = "Name Is Not Valid !!!";
                    }
                }
            }
        }

        public string Get_Player_Name()
        {
            return Player_Name; // Trả về tên nhân vật
        }


        public Material[] Get_Skin_Design() // trả về skin của nhân vật
        {
            return Current_Body;
        }

        public void Done()
        {
            if (Text_Name_Check.text.Equals("Name Is Valid"))
            {
                EndTransition.Instance.TriggerAnimation();
                ControlLoading.Instance.Loadbar(2);
            }else
            {
                Text_Name_Check.color = Color.black;
                Text_Name_Check.text = "Please Enter Your Name !!!";
            }
        }
    }
}
