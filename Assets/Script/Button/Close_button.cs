using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_button : MonoBehaviour
{
    public void button_on()
    {
        if (Game_system.get_windows() == "main")
        {

        }
        else if (Game_system.get_windows() == "achievement")
        {
            GameObject.Find("Achievement").GetComponent<Icon_move>().move();

            GameObject.Find("Logo").GetComponent<Icon_move>().move();
            GameObject.Find("Start_button").GetComponent<Icon_move>().move();
            GameObject.Find("Achievement_button").GetComponent<Icon_move>().move();
            GameObject.Find("Bag_button").GetComponent<Icon_move>().move();

            Game_system.set_windows("main");
        }
    }
}
