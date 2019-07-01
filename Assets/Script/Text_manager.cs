using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_manager : MonoBehaviour
{
    public Text Score_text;
    public Text End_Score_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score_text.text = "Score : " + Game_system.get_score() + " ";
        End_Score_text.text = "Score : " + Game_system.get_score() + "\nHigh Score : " + Game_system.get_high_score();
    }
}
