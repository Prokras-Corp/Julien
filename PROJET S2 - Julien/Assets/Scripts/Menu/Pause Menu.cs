using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public string menuName;
    public bool open;
    
    // Create A Invulnerable method

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        GameIsPaused = true;
        gameObject.SetActive(true);
    }

    void Resume()
    {
        GameIsPaused = false;
        gameObject.SetActive(false); 
    }
}
