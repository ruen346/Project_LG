using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_system : MonoBehaviour
{
    public void start_game()
    {
        SceneManager.LoadScene("Game_scene");
        Game_system.reset();
    }

    public void return_game()
    {
        SceneManager.LoadScene("Main_scene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
