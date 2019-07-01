using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_position : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Game_system.get_play() == 1)
            transform.Translate(3 * Time.deltaTime, 0, 0);

        if (transform.position.x > 22 && Game_system.get_level() == 1)
            Game_system.level_up();

        if (transform.position.x > 43 && Game_system.get_level() == 2)
            Game_system.level_up();
    }
}
