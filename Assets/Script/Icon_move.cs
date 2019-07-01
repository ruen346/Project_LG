using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon_move : MonoBehaviour
{
    public float delay;
    public float move_x;
    public float move_y;

    int num = 20;

    IEnumerator Start()
    {
        transform.Translate(-move_x, -move_y, 0);

        yield return new WaitForSeconds(delay);

        while (num != 0)
        {
            transform.Translate(move_x / 20, move_y / 20, 0);
            num--;

            yield return new WaitForSeconds(0.005f);
        }
    }
}
