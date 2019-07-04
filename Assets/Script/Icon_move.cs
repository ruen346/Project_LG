using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon_move : MonoBehaviour
{
    public bool start_move = false;

    public float delay;
    public float move_x;
    public float move_y;

    public int num_max = 20;
    private int num;

    private bool open = false;

    IEnumerator Start()
    {
        num = num_max;

        transform.Translate(-move_x, -move_y, 0);

        if (start_move == true)
        {
            yield return new WaitForSeconds(delay);

            while (num != 0)
            {
                transform.Translate(move_x / 20, move_y / 20, 0);
                num--;

                yield return new WaitForSeconds(0.005f);
            }

            open = true;
        }
    }

    public void move()
    {
        StartCoroutine(moves());
    }

    IEnumerator moves()
    {
        if (open == false)
        {
            while (num != 0)
            {
                transform.Translate(move_x / num_max, move_y / num_max, 0);
                num--;

                yield return new WaitForSeconds(0.005f);
            }
            num = num_max;
            open = true;
        }
        else
        {
            while (num != 0)
            {
                transform.Translate(-move_x / num_max, -move_y / num_max, 0);
                num--;

                yield return new WaitForSeconds(0.005f);
            }
            num = num_max;
            open = false;
        }
    }
}
