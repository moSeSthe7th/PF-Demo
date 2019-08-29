using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionButton : MonoBehaviour
{
    int levelNo;

    public void SelectLevel()
    {
        int.TryParse(GetComponentInChildren<Text>().text, out levelNo);
        PlayerPrefs.SetInt("Current Level", levelNo);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
