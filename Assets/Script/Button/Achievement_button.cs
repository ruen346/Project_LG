using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement_button : MonoBehaviour
{
    public void button_on()
    {
        if (Game_system.get_windows() == "main")
        {
            Game_system.set_windows("achievement");
        }
    }
}
