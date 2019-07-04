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
            Game_system.set_windows("main");
        }
    }
}
