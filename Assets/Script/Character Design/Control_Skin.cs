using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Script.Character_Design
{
    public class Control_Skin : MonoBehaviour, IButtonDesignCharacter
    {
        [SerializeField] List<string> Skins = new List<string>() { "White Skin", "Yellow Skin", "Black Skin" };

        [SerializeField] private TextMeshProUGUI Skin_Text;

        [SerializeField] private int Curren_Skin = 0;

        void Start()
        { 
            Skin_Text.text = Skins[Curren_Skin];
        }

        public void TurnLeft()
        {
            if (Curren_Skin > 0)
            {
                Curren_Skin--;
                Skin_Text.text = Skins[Curren_Skin];
            }
            else
            {
                Curren_Skin = Skins.Count - 1;
                Skin_Text.text = Skins[Curren_Skin];
            }
        }

        public void TurnRight()
        {
            if (Curren_Skin < Skins.Count - 1)
            {
                Curren_Skin++;
                Skin_Text.text = Skins[Curren_Skin];
            }
            else
            {
                Curren_Skin = 0;
                Skin_Text.text = Skins[Curren_Skin];
            }
        }
    }
}


