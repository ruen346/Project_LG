using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public float start;
    public float end;

    public bool return_trans = false;

    // Start is called before the first frame update
    void Start()
    {
        if (return_trans == true)
        {
            Destroy(gameObject, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (return_trans == false)
        {
            if (transform.position.x < start)
                transform.Translate(end, 0, 0);
        }
    }
}
