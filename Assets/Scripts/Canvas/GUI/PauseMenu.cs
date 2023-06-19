using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PauseMenu : MonoBehaviour
{
    private GameObject _pauseMenuUI;
    private GameObject _HUD;
    public static bool GameIsPaused = false;
    InputLoadManager input;

    private void Start()
    {
        _pauseMenuUI = GameObject.FindGameObjectWithTag("PauseMenuUI");
        _HUD = GameObject.FindGameObjectWithTag("HUD");
        input = GameObject.FindGameObjectWithTag("Main").GetComponent<MainScene>().inputLoadManager;

        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if(input.Menu())    
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        _HUD.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        _pauseMenuUI.SetActive(true);
        _HUD.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
