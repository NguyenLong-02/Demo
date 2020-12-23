using Assets.Script.Store_Data;
using Assets.Script.System;
using TMPro;
using UnityEngine;

public class Set_Text : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Load_Data_Text;
    public void Set_Load_Text(string name)
    {
        Load_Data_Text.text = name;
    }
    private void Start()
    {
        Load_Data_Text.text = Character.Instance.player_Name;
    }
}
