using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed;
    public float angle = 0;
    public int destroy_time = 5;

    public bool turn_true = false; // 장애물이 돈다
    public bool down_true = false; // 장애물이 중간에 내려온다
    public bool updown_true = false; // 장애물이 위아래로 움직인다
    
    int updown_switch = 0;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroy_time);
    }

    // Update is called once per frame
    void Update()
    {
        if (turn_true)
        {
            transform.Rotate(Vector3.forward, -angle);
        }

        if (down_true)
        {
            if(transform.position.x < 3 && transform.position.y > -0.7)
                transform.Translate(0, (-speed / 2) * Time.deltaTime, 0);
        }

        if (updown_true)
        {
            if(updown_switch == 0)
            {
                if (transform.position.y > -0.8)
                    transform.Translate(0, (-speed / 2) * Time.deltaTime, 0);
                else
                    updown_switch = 1;
            }
            else
            {
                if (transform.position.y < 0.4)
                    transform.Translate(0, (speed / 2) * Time.deltaTime, 0);
                else
                    updown_switch = 0;
            }    
        }

        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (turn_true)
        {
            angle += Time.deltaTime * 300;
            transform.Rotate(Vector3.forward, angle);
        }
    }
}
