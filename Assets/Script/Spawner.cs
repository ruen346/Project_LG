using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawn_prefab;
    public GameObject[] tile_prefab;

    int[,] tile_mod = new int[2,3]//타일들 패턴
    {
        { 1,1,1},{ 3,0,2}
    };
    int[] tile_mod_num = new int[2]//타일패턴 갯수
    {3, 3};
    int tile_mod_last = -1; // 남은 타일 갯수
    int tile_mod_choose = 0; // 현재 타일 번호

    public float delay_time;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);

        while (true)
        {
            if (Game_system.get_play() == 1)
            {
                int level = Game_system.get_level(); // level별 종류추가 예정!

                int spawn_choose = Random.Range(0, 7);

                switch (spawn_choose)
                {
                    case 0:
                        Instantiate(spawn_prefab[0], new Vector2(4.5f, -0.7f), transform.rotation);
                        break;
                    case 1:
                        Instantiate(spawn_prefab[1], new Vector2(4.5f, -0.7f), transform.rotation);
                        break;
                    case 2:
                        Instantiate(spawn_prefab[2], new Vector2(4.5f, 0.3f), transform.rotation);
                        break;
                    case 3:
                        Instantiate(spawn_prefab[3], new Vector2(4.5f, -1.22f), transform.rotation);
                        break;
                    case 4:
                        Instantiate(spawn_prefab[4], new Vector2(4.5f, 0.3f), transform.rotation);
                        break;
                    case 5:
                        float make_y = (Random.Range(-7, 3) - 7) / 10;
                        Instantiate(spawn_prefab[5], new Vector2(4.5f, make_y), transform.rotation);
                        break;
                    case 6:
                        Instantiate(spawn_prefab[6], new Vector2(4.5f, -1.1f), transform.rotation);
                        break;
                }
            }

            yield return new WaitForSeconds(delay_time + Random.Range(-0.2f, 0.2f));
        }
    }

    public void spawn_tile(float x_position)
    {
        if (Game_system.get_play() == 1)
        {
            tile_mod_last--;

            if (tile_mod_last < 0)
            {
                tile_mod_choose = Random.Range(0, 2);
                tile_mod_last = tile_mod_num[tile_mod_choose] - 1;
            }

            switch (tile_mod[tile_mod_choose,tile_mod_last])
            {
                case 0:
                    Instantiate(tile_prefab[0], new Vector2(x_position, -2.1f), transform.rotation);
                    break;
                case 1:
                    Instantiate(tile_prefab[1], new Vector2(x_position, -2.1f), transform.rotation);
                    break;
                case 2:
                    Instantiate(tile_prefab[2], new Vector2(x_position, -2.1f), transform.rotation);
                    break;
                case 3:
                    Instantiate(tile_prefab[3], new Vector2(x_position, -2.1f), transform.rotation);
                    break;
            }
        }
    }
}
