using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon_move2 : MonoBehaviour
{
    public int move_x;
    public int move_y;

    int num_max;
    int num;

    // Start is called before the first frame update
    void Start()
    {
        num_max = 20;
        num = num_max;

        transform.Translate(-move_x, -move_y, 0);
    }

    public void move()
    {
        StartCoroutine(moves());
    }
    public void move_return()
    {
        StartCoroutine(moves_return());
    }

    IEnumerator moves()
    {
        while (num != 0)
        {
            transform.Translate(move_x / num_max, move_y / num_max, 0);
            num--;

            yield return new WaitForSeconds(0.005f);
        }
        num = num_max;
    }
    IEnumerator moves_return()
    {
        while (num != 0)
        {
            transform.Translate(-move_x / num_max, -move_y / num_max, 0);
            num--;

            yield return new WaitForSeconds(0.005f);
        }
        num = num_max;
    }
}
