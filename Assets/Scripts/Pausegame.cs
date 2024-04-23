using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausegame : MonoBehaviour
{
    private void OnEnable()
    {
        // Pause the game when the settings panel is opened
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        // Resume the game when the settings panel is closed
        Time.timeScale = 1f;
    }
}
