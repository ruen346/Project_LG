using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement_Manager : MonoBehaviour
{
    public Slider achievement_bar1;
    public Slider achievement_bar2;
    public Slider achievement_bar3;
    public Slider achievement_bar4;

    // Start is called before the first frame update
    void Awake()
    {
        achievement_bar1.value = 8;
        achievement_bar2.value = 10;
        achievement_bar3.value = 12;
        achievement_bar4.value = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
