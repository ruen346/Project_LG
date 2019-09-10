using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    bool is_pause;

    private void Awake()
    {
        is_pause = false;
    }

    public void game_pause()
    {
        if (!is_pause)
        {
            pause.SetActive(true);
            is_pause = true;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            pause.SetActive(false);
            is_pause = false;
        }
    }
}
