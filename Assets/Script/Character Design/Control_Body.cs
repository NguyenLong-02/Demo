using Assets.Script.Transition;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Character_Design
{
    public class Control_Body : MonoBehaviour, IButtonDesignCharacter
    {
        [SerializeField] private List<Material> White_Bodys = new List<Material>();
        [SerializeField] private List<Material> Yello_Bodys = new List<Material>();
        [SerializeField] private List<Material> Black_Bodys = new List<Material>();

        private readonly Dictionary<int, List<Material>> Body_Dict = new Dictionary<int, List<Material>>();// Lưu dưới dạng dic 
        // Nếu da đen thì có một list riêng, tương tự với da vàng và da trắng

        private int Current_Skin = 0;
        private int Current_Body_Index = 0;

        private void Start()
        {
            Body_Dict.Add(0, White_Bodys);
            Body_Dict.Add(1, Yello_Bodys);
            Body_Dict.Add(2, Black_Bodys);
            Deit.Instance.Set_Body(1, Body_Dict[Current_Skin][Current_Body_Index]);
        }

        private void Update()
        {
            try
            {
                if (Deit.Instance.GetSkin().Equals("White Skin"))
                {
                    Current_Skin = 0;
                    Deit.Instance.Set_Body(1, Body_Dict[Current_Skin][Current_Body_Index]);

                }
                else if (Deit.Instance.GetSkin().Equals("Yellow Skin"))
                {
                    Current_Skin = 1;
                    Deit.Instance.Set_Body(1, Body_Dict[Current_Skin][Current_Body_Index]);
                }
                else
                {
                    Current_Skin = 2;
                    Deit.Instance.Set_Body(1, Body_Dict[Current_Skin][Current_Body_Index]);
                }
            }catch(Exception)
            {
                Debug.Log("");
            }
        }


        public void TurnLeft()
        {
            if(Current_Body_Index > 0)
            {
                Current_Body_Index--;
            }
            else
            {
                Current_Body_Index = Body_Dict[Current_Skin].Count - 1;
            }
        }

        public void TurnRight()
        {
            if (Current_Body_Index < Body_Dict[Current_Skin].Count - 1)
            {
                Current_Body_Index++;
            }
            else
            {
                Current_Body_Index = 0;
            }
        }
    }
}


