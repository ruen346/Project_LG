using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public GameObject rain;
    
    IEnumerator Start()
    {
        while (true)
        {
            if (Game_system.get_play() == 1)
            {
                float x_range = Random.Range(-4f, 8f);
                Instantiate(rain, new Vector2(x_range, 2.5f), transform.rotation);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
    
    void Update()
    {

    }
}
