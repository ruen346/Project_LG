using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_system : MonoBehaviour
{
    static int score = 0;
    static int high_score = 0;
    static int level = 1;
    static bool sounds = true; // 사운드 온오프

    static int game_play = 1;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("System");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    IEnumerator Start()
    {
        score = 0;
        level = 1;
        game_play = 0;
        high_score = PlayerPrefs.GetInt("high_score", 0);

        while (true)
        {
            if(game_play == 1) 
                score += 10;

            yield return new WaitForSeconds(0.5f);
        }
    }
    
    public static void reset()
    {
        score = 0;
        level = 0;
        game_play = 1;
    }

    public static int get_score()
    {
        return score;
    }

    public static int get_high_score()
    {
        return high_score;
    }

    public static int get_level()
    {
        return level;
    }

    public static int get_play()
    {
        return game_play;
    }

    public static bool get_sounds()
    {
        return sounds;
    }

    public static void set_sounds(bool on_sounds)
    {
        sounds = on_sounds;
        FindObjectOfType<Sound_control>().volume();
    }

    public static void level_up()
    {
        level++;
    }

    public void game_end()
    {
        game_play = 0;

        if (high_score < score)
        {
            high_score = score;
            PlayerPrefs.SetInt("high_score", high_score);
        }

        FindObjectOfType<Score_board>().move();
    }

    // Update is called once per frame
    void Update()
    {

    }
}