using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_manager : MonoBehaviour
{
    public Text Score_text;
    public Text Score_end_text;
    public Text Score_etc_text;

    void Update()
    {
        Score_text.text = string.Format("{0:#,##0}", Game_system.get_score());
        Score_end_text.text = string.Format("{0:#,##0}", Game_system.get_score());
        Score_etc_text.text = (int)Game_system.get_high_score() / 10 + "원\n\n최고기록 : " + string.Format("{0:#,##0}", Game_system.get_high_score());
    }
}
