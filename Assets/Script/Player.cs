using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float jump_power = 7; // 점프 강도
    float collider_delay = 0; // 충돌시 무적 시간
    int max_hp;
    int hp;

    public int jump_num = 2; // 점프 가능 횟수
    public bool attack = true;

    Collider2D this_collision;

    Rigidbody2D rigid;
    SpriteRenderer render;

    Vector2 movement;

    Animator animator;

    public Slider hp_slider;
    public GameObject attack_object;

    //float slide_delay = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collider_delay <= 0 && attack_object.activeSelf == false)
        {
            collider_delay = 2;
            render.color = new Color(1, 1, 1, 0.5f);
            StartCoroutine(Crash());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Tile")
        {
            if (collision.collider.transform.position.y + 0.5f < transform.position.y)
            {
                jump_num = 2;
                animator.SetBool("Jump", true);
            }
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        render = gameObject.GetComponent<SpriteRenderer>();

        max_hp = Game_system.get_max_hp();
        hp_slider.maxValue = max_hp;
        hp = max_hp;
        hp_slider.value = hp;

        StartCoroutine(Move_back());
    }

    public void Jump()
    {
        if (jump_num > 0)
        {
            rigid.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jump_power);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

            animator.SetBool("Jump", false);
            jump_num--;
        }
    }

    public void Attack()
    {
        if (attack == true)
        {
            attack = false;
            attack_object.SetActive(true);
            StartCoroutine(Attack_delay());
        }
    }

    IEnumerator Attack_delay()
    {
        for(int i=0; i<6; i++)
        {
            attack_object.transform.Rotate(Vector3.forward * -15);
            yield return new WaitForSeconds(0.005f);
        }
        attack_object.SetActive(false);
        attack_object.transform.Rotate(Vector3.forward * 90);

        yield return new WaitForSeconds(0.5f);
        attack = true;
    }


    IEnumerator Crash()
    {
        hp -= 20;
        hp_slider.value = hp;

        if (hp <= 0)
            FindObjectOfType<Game_system>().game_end();

        while (collider_delay > 0)
        {
            collider_delay -= 0.1f;

            yield return new WaitForSeconds(0.01f);
        }
        render.color = new Color(1, 1, 1, 1);
    }

    IEnumerator Move_back()
    {
        while (Game_system.get_play() == 1)
        {
            hp -= 1;
            hp_slider.value = hp;

            if (hp <= 0)
                FindObjectOfType<Game_system>().game_end();

            if(gameObject.transform.position.y < -2.2f)
                FindObjectOfType<Game_system>().game_end();

            yield return new WaitForSeconds(1f);
        }
    }
}
