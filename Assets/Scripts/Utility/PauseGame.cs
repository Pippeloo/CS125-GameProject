using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f; // Set time scale to zero to pause the game
        isPaused = true;
        // You might want to show a pause menu or do other pause-related actions here
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Set time scale back to normal to resume the game
        isPaused = false;
        // You might want to hide the pause menu or resume any paused actions here
    }
}