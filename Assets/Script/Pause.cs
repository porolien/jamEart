using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool GameIsPaused;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseFonction()
    {
        if (GameIsPaused)
        {
            Resume(true);
        }
        else
        {
            Paus(true);
        }
    }
    public void Resume(bool Menu)
    {
        Debug.Log("resume");
        if (Menu)
        {
            pauseMenuUI.SetActive(false);
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Paus(bool Menu)
    {
        Debug.Log("pause");
        if (Menu)
        {
            pauseMenuUI.SetActive(true);
        }
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
