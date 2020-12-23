using UnityEngine;
using Assets.Script.Character_Design;
using TMPro;
using System;
using Assets.Script.Transition;

namespace Assets.Script.Store_Data
{
    public class Character : MonoBehaviour
    {
        public SkinnedMeshRenderer skinned;
        public Material[] Character_Material = new Material[2];     
        public TextMeshProUGUI Name_Play;
        public string player_Name;
        public bool _isNewGame;
        public static Character Instance;

        public float currentHeal;
        // Update is called once per frame
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            try
            {
                Name_Play.text = Deit.Instance.Get_Player_Name();
                Character_Material = Deit.Instance.Get_Skin_Design();
                skinned.sharedMaterials = Character_Material;
            }
            catch (Exception) { }


            player_Name = Name_Play.text;
        }

        private void Update()
        {
            // Liên tục lưu trữ skin mà mình đang dùng
            Character_Material = skinned.sharedMaterials;
        }
    }
}
