using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject levelPassedPanel;
    public GameObject levelSelectorPanel;
    
    void Start()
    {
        gameOverPanel.SetActive(false);
        levelPassedPanel.SetActive(false);
        levelSelectorPanel.SetActive(false);
    }

    public void LevelPassed()
    {
        Time.timeScale = 0;
        levelPassedPanel.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

}
