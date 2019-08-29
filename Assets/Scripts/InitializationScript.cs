using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationScript : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
        DataScript.isGameStarted = false;
        DataScript.waypoints = new List<Vector3>();
        DataScript.waypoints.Clear();
        DataScript.possibleObstaclePositions = new List<Vector3>();
        DataScript.possibleObstaclePositions.Clear();
        DataScript.currentLevel = PlayerPrefs.GetInt("Current Level", 1);

        Debug.Log("Level: " + DataScript.currentLevel);
    }
}
