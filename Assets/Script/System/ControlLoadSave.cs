using Assets.Script.Character_Design;
using Assets.Script.Play_Game;
using Assets.Script.Store_Data;
using Assets.Script.Transition;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Script.System
{
    class ControlLoadSave : MonoBehaviour
    {
        public static ControlLoadSave Instance;


        [SerializeField] GameObject LoadPrefabs;
        [SerializeField] GameObject LoadPannelPrefabs;
        [SerializeField] List<GameObject> Button_enable;
        [SerializeField] bool isOpenLoadPannel = false;

        private void Awake()
        {
            Instance = this;
        }


        public void SaveData()
        {
            LoadSaveSystem.SavePlayer();
            // Sau khi Save thì trong LoadSaveSystem biến Save_List sẽ tồn tại một giá trị nào đó để load
            // Có thể dùng 2 cách này để có thể AddListener với những fucion có paramaster
            // Bởi vì AddListener chỉ là có thể Add những fucion là ko tồn tại paramaster
            // Vậy nên ta dùng Anonymouse Method để AddListener vào là một fucion Anonymouse không có paramaster mà trong Anonymouse MEthod
            // Chúng ta tiến hành việc gọi những Fucion có Paramaster khác
            // Sở đồ AddListener => Anonymouse Method => Funcion(Paramaster);

            /*                loadbuttonclone.GetComponent<Button>().onClick.AddListener(delegate { LoadData(player); });*/
        }
        public void OpenLoadPannel()
        {
            isOpenLoadPannel = !isOpenLoadPannel;
            LoadPannelPrefabs.SetActive(isOpenLoadPannel);
        }

        public void LoadData()
        {
            Data GameData = LoadSaveSystem.LoadPlayer();

            if (GameData != null)
            {
                try
                {
                    // Get Resousce Form DATA BASE
                    Resousce.Instance.woods = GameData.woods;
                    Resousce.Instance.rocks = GameData.rocks;
                    Resousce.Instance.foods = GameData.foods;
                    Resousce.Instance.twigs = GameData.twigs;
                    Resousce.Instance.small_stone = GameData.small_stone;

                    // Get Character Form DATA BASE


                    Character.Instance.Name_Play.text = GameData.Player_Name;
                    Character.Instance.currentHeal = GameData.CurrentHeal;

                    // Get List Form DATA BASE

                }
                catch (Exception) {
                    Debug.Log("Error"); 
                }
            }

            else Debug.Log("Null");
        }
    }
}

