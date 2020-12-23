using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Character_Design;
using System;
using Assets.Script.Play_Game;
using Assets.Script.Store_Data;

[System.Serializable] // Những class Data cần System.Seriablizable thì mới có thể thực hiện load save bằng fomatter được
public class Data
{
    public int woods;
    public int rocks;
    public int foods;
    public int twigs;
    public int small_stone;

    public string Player_Name;

    public float CurrentHeal;

    public Data() // Resousce ở đây là tài nguyên thiên nhiên
    {

        // Get Resousce Data For Saving


        // Get Player Name, Skin And Heal
        try
        {
            woods = Resousce.Instance.woods;
            rocks = Resousce.Instance.rocks;
            foods = Resousce.Instance.foods;

            twigs = Resousce.Instance.twigs;
            small_stone = Resousce.Instance.small_stone;
            CurrentHeal = Character.Instance.currentHeal;

            // Get List Of Quest
        }
        catch (Exception) { }
    }
}
