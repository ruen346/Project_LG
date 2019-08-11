using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance_position : MonoBehaviour
{
    public Slider distance_bar;

    void Start()
    {
        StartCoroutine(Update_meter());
    }

    IEnumerator Update_meter()
    {
        while (Game_system.get_play() == 1)
        {
            Game_system.set_meter(Game_system.get_meter() + 1);

            if (Game_system.get_meter() >= 120)
                Game_system.level_up();

            if (Game_system.get_meter() >= 240)
                Game_system.level_up();

            distance_bar.value = Game_system.get_meter();

            yield return new WaitForSeconds(0.5f);
        }
    }
}
