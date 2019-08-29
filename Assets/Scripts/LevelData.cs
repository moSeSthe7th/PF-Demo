using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public int obstaclePositionCount;
    public int roadCount;
   
    public void TakeLevelData(int levelNo)
    {
        switch (levelNo)
        {
            case 1:
                roadCount = 8;
                obstaclePositionCount = 6;
                break;
            case 2:
                roadCount = 12;
                obstaclePositionCount = 6;
                break;
            case 3:
                roadCount = 16;
                obstaclePositionCount = 8;
                break;
        }
    }
}
