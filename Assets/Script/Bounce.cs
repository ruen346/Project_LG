using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    int time = 0;
    float scale = 1;

    IEnumerator Start()
    {
        time = 0;
        while (true)
        {
            if (time >= 180 && time < 190)
            {
                scale += 0.02f;
                gameObject.transform.localScale = new Vector2(1, scale);
            }
            else if (time >= 190 && time < 200)
            {
                scale -= 0.02f;
                gameObject.transform.localScale = new Vector2(1, scale);
            }
            else if (time == 200)
                time = 0;

            time++;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
