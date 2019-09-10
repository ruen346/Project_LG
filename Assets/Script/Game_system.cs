using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_system : MonoBehaviour
{
    static int score;
    static int high_score;
    static int level;
    static int meter;
    static int max_hp;
    static bool sounds; // 사운드 온오프
    static string windows; // 열린창 main/bag/achievement
    static int game_play; // 게임 플레이 여부
    static bool icon_on; // 아이콘 이동중 false


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("System");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);


        score = 0;
        high_score = PlayerPrefs.GetInt("high_score", 0);
        level = 1;
        meter = 0;
        max_hp = 100;

        sounds = true;
        windows = "main";
        game_play = 0;
        icon_on = false;
    }

    IEnumerator Start()
    {
        while (true)
        {
            if (game_play == 1)
                score += 100;

            yield return new WaitForSeconds(0.5f);
        }
    }

    public static void reset()
    {
        score = 0;
        level = 0;
        meter = 0;
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

    public static int get_meter()
    {
        return meter;
    }

    public static int get_max_hp()
    {
        return max_hp;
    }

    public static int get_play()
    {
        return game_play;
    }

    public static bool get_sounds()
    {
        return sounds;
    }

    public static string get_windows()
    {
        return windows;
    }

    public static bool get_icon_on()
    {
        return icon_on;
    }

    public static void set_score(int on_score)
    {
        score = on_score;
    }

    public static void set_meter(int on_meter)
    {
        meter = on_meter;
    }

    public static void set_sounds(bool on_sounds)
    {
        sounds = on_sounds;
        FindObjectOfType<Sound_control>().volume();
    }

    public static void set_windows(string on_windows)
    {
        windows = on_windows;
    }

    public static void set_icon_on(bool on_icon_on)
    {
        icon_on = on_icon_on;
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
}