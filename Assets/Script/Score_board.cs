using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_board : MonoBehaviour
{
    bool move_down = false;

    public void move()
    {
        move_down = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y > 0 + 540 && move_down == true)
            transform.Translate(0, -50, 0);
    }
}
