using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    
   public void PlayNextLevel()
    {
        if(DataScript.currentLevel < 3)
        {
            PlayerPrefs.SetInt("Current Level", DataScript.currentLevel + 1);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
    }
}
