using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Sprite sprite_off;
    public Sprite sprite_on;

    // Start is called before the first frame update
    void Start()
    {
        if (Game_system.get_sounds() == true)
        {
            this.GetComponent<Image>().sprite = sprite_on;
        }
        else
        {
            this.GetComponent<Image>().sprite = sprite_off;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button_on()
    {
        if (Game_system.get_sounds() == true)
        {
            Game_system.set_sounds(false);
            this.GetComponent<Image>().sprite = sprite_off;
            //Sound_control.volume();
        }
        else
        {
            Game_system.set_sounds(true);
            this.GetComponent<Image>().sprite = sprite_on;
        }
    }
}
