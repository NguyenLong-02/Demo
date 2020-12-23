using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Character_Design
{
    public class Control_Head : MonoBehaviour, IButtonDesignCharacter
    {
        [SerializeField] private List<Material> White_Heads = new List<Material>();
        [SerializeField] private List<Material> Yello_Heads = new List<Material>();
        [SerializeField] private List<Material> Black_Heads = new List<Material>();

        private readonly Dictionary<int, List<Material>> Head_Dict = new Dictionary<int, List<Material>>(); // Lưu dưới dạng dic 
        // Nếu da đen thì có một list riêng, tương tự với da vàng và da trắng

        private int Current_Skin = 0; // Mauf da
        private int Current_Body_Index = 0; // Index của body hiện tại

        private void Start()
        {
            Head_Dict.Add(0, White_Heads);
            Head_Dict.Add(1, Yello_Heads);
            Head_Dict.Add(2, Black_Heads);
            Deit.Instance.Set_Body(0, Head_Dict[Current_Skin][Current_Body_Index]);
        }
        private void Update()
        {
            try
            {
                if (Deit.Instance.GetSkin().Equals("White Skin"))
                {
                    Current_Skin = 0;
                    Deit.Instance.Set_Body(0, Head_Dict[Current_Skin][Current_Body_Index]);

                }
                else if (Deit.Instance.GetSkin().Equals("Yellow Skin"))
                {
                    Current_Skin = 1;
                    Deit.Instance.Set_Body(0, Head_Dict[Current_Skin][Current_Body_Index]);
                }
                else
                {
                    Current_Skin = 2;
                    Deit.Instance.Set_Body(0, Head_Dict[Current_Skin][Current_Body_Index]);
                }
            } catch (Exception)
            {
                
            }
        }


        public void TurnLeft()
        {
            if (Current_Body_Index > 0)
            {
                Current_Body_Index--;
            }
            else
            {
                Current_Body_Index = Head_Dict[Current_Skin].Count - 1;
            }
        }

        public void TurnRight()
        {
            if (Current_Body_Index < Head_Dict[Current_Skin].Count - 1)
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


