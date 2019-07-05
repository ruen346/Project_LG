using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag_button : MonoBehaviour
{
    public void button_on()
    {
        if (Game_system.get_windows() == "main" && Game_system.get_icon_on() == true)
        {
            // GameObject.Find("Achievement").GetComponent<Icon_move>().move();

            GameObject.Find("Logo").GetComponent<Icon_move>().move();
            GameObject.Find("Start_button").GetComponent<Icon_move>().move();
            GameObject.Find("Achievement_button").GetComponent<Icon_move>().move();
            GameObject.Find("Bag_button").GetComponent<Icon_move>().move();

            Game_system.set_windows("bag");
            Game_system.set_icon_on(false);
        }
    }
}
