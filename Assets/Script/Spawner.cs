using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawn_prefab;
    public float[] spawn_y;

    public GameObject spawn_prefab1;
    public GameObject spawn_prefab2;
    public GameObject spawn_prefab3;
    public GameObject spawn_prefab4;
    public GameObject spawn_prefab5;
    public GameObject spawn_prefab6;
    public GameObject spawn_prefab7;

    public float delay_time;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);

        while (true)
        {
            if (Game_system.get_play() == 1)
            {
                int level = Game_system.get_level(); // level별 종류추가 예정!

                int spawn_choose = Random.Range(1, 8);
                //int spawn_choose = 7;

                switch (spawn_choose)
                {
                    case 1:
                        Instantiate(spawn_prefab1, new Vector2(4.5f, -0.7f), transform.rotation);
                        break;
                    case 2:
                        Instantiate(spawn_prefab2, new Vector2(4.5f, -0.7f), transform.rotation);
                        break;
                    case 3:
                        Instantiate(spawn_prefab3, new Vector2(4.5f, 0.3f), transform.rotation);
                        break;
                    case 4:
                        Instantiate(spawn_prefab4, new Vector2(4.5f, -1.22f), transform.rotation);
                        break;
                    case 5:
                        Instantiate(spawn_prefab5, new Vector2(4.5f, 0.3f), transform.rotation);
                        break;
                    case 6:
                        float make_y = (Random.Range(-7, 3) - 7) / 10;
                        Instantiate(spawn_prefab6, new Vector2(4.5f, make_y), transform.rotation);
                        break;
                    case 7:
                        Instantiate(spawn_prefab7, new Vector2(4.5f, -1.1f), transform.rotation);
                        break;
                }
            }

            yield return new WaitForSeconds(delay_time + Random.Range(-0.2f, 0.2f));
        }
    }

    void Update()
    {
        
    }
}
