using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsOpenerButton : MonoBehaviour
{
    public GameObject levelsPanel;

    public void OpenCloseLevelsPanel()
    {
        if (levelsPanel.activeSelf)
        {
            Time.timeScale = 1;
            levelsPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            levelsPanel.SetActive(true);
        }
            
    }
}
