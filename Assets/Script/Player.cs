using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider jump_bar;

    //public float jump_power = 1;
    public float jump_charage = 6;
    float collider_delay = 0; // 충돌시 무적 시간

    Collider2D this_collision;

    Rigidbody2D rigid;
    SpriteRenderer render;

    Vector2 movement;
    bool jump = false;

    Animator animator;

    //float slide_delay = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collider_delay);
        /*
        if (slide_delay == 0 && collision.tag == "Slide_back")
        {
            this_collision = collision;
            slide_delay = 10;    
        }
        */
        if (collider_delay <= 0)
        {
            collider_delay = 2;
            render.color = new Color(1, 1, 1, 0.5f);
            StartCoroutine(Crash());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        render = gameObject.GetComponent<SpriteRenderer>();

        StartCoroutine(Move_back());
    }

    // Update is called once per frame
    void Update()
    {
        /* 과거의 유산
        if (transform.position.y <= -0.45 && (transform.rotation.z < 0.5 && transform.rotation.z > -0.5))
            jump = true;
        if(transform.rotation.z > 0.5 || transform.rotation.z < -0.5)
        {
            transform.Translate(-3 * Time.deltaTime, 0, 0, Space.World);
        }

        if(slide_delay != 0) // 미끄러짐
        {
            transform.Rotate(0, 0, 3);
            transform.Translate(-0.13f, 0.15f, 0, Space.World);
            this_collision.transform.Translate(-0.3f, 0, 0);
            slide_delay--;
        }
        */
        if (transform.position.y <= -0.57)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        if (transform.position.x < -4.5 && Game_system.get_play() == 1)
        {
            FindObjectOfType<Game_system>().game_end();
        }

        if (Input.GetMouseButton(0))
        {
            if (jump_charage < 12)
            {
                jump_charage += Time.deltaTime * 20;

                if (jump_charage > 12)
                    jump_charage = 12;

                jump_bar.value = jump_charage;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (jump)
                Jump();

            jump_charage = 6;
            jump_bar.value = jump_charage;
        }

        animator.SetBool("Jump", jump);
    }

    public void Jump()
    {
        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jump_charage);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        jump_bar.value = jump_charage;
    }

    IEnumerator Crash()
    {
        while (collider_delay > 0)
        {
            if(collider_delay > 1.7)
                transform.Translate(-0.15f, 0, 0, Space.World);

            collider_delay -= 0.05f;

            yield return new WaitForSeconds(0.005f);
        }
        render.color = new Color(1, 1, 1, 1);
    }

    IEnumerator Move_back()
    {
        while (Game_system.get_play() == 1)
        {
            transform.Translate(-0.005f, 0, 0, Space.World);

            yield return new WaitForSeconds(0.05f);
        }
    }
}
