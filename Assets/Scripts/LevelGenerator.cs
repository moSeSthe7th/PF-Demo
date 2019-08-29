using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject road;
    private Vector3 initialRoadPos;
    bool isRotated;
    bool isRotateRight;
    public GameObject finishLine;

    float roadPositionDistance;

    LevelData levelData;
    ObstacleCreator obstacleCreator;
    
    void Start()
    {
        levelData = GetComponent<LevelData>();
        obstacleCreator = GetComponent<ObstacleCreator>();

        roadPositionDistance = road.transform.localScale.x * 4;
        isRotated = false;
        isRotateRight = Random.value >= 0.5;
        initialRoadPos = new Vector3(0, 0, 0);

        StartGame();
        
    }
    

    Vector3 RoadPosSelector()
    {
        bool posSelector = Random.value >= 0.5f;
        Vector3 dummyVec = initialRoadPos;
        

        dummyVec.x += roadPositionDistance;
        if (isRotateRight)
            dummyVec.z += roadPositionDistance;
        else
            dummyVec.z -= roadPositionDistance;
       
        initialRoadPos = dummyVec;
        
        return initialRoadPos;
    }

    Quaternion roadRotationSelector()
    {
        Quaternion quaternion = new Quaternion();

        if (isRotated)
        {
            isRotated = false;
            quaternion.eulerAngles = new Vector3(0, 0, 0);
        }

        else
        {
            isRotated = true;
            quaternion.eulerAngles = new Vector3(0, 90f, 0);
        }

        return quaternion;
    }

    void StartGame()
    {
        levelData.TakeLevelData(DataScript.currentLevel);
        Quaternion finishLineRotation = new Quaternion();

        Instantiate(road, initialRoadPos, Quaternion.identity);
        DataScript.waypoints.Add(new Vector3(roadPositionDistance, 0.5f, 0));

        for (int i = 0; i < levelData.roadCount; i++)
        {
            Vector3 roadPos = RoadPosSelector();
            Quaternion roadRotation = roadRotationSelector();
            finishLineRotation = roadRotation;
            GameObject currentRoad = Instantiate(road, roadPos, roadRotation);

            CreateWaypoint(roadPos);
        }


        CreateFinishLine(finishLineRotation);
        GenerateObstacles();
        DataScript.isGameStarted = true;
    }

    void CreateFinishLine(Quaternion finishLineRotation)
    {
        Vector3 finishLinePosition = DataScript.waypoints[DataScript.waypoints.Count - 1];
        finishLinePosition.y = 0.1f;
        if (finishLineRotation.y == 0)
        {
            finishLinePosition.x += 2.5f;
        }
        else
        {
            finishLinePosition.z += 2.5f;
        }
        
        Instantiate(finishLine, finishLinePosition, finishLineRotation);
    }

    void CreateWaypoint(Vector3 roadPos)
    {
        Vector3 waypoint = roadPos;

        if (isRotated)
        {

            if (isRotateRight)
                waypoint.z += roadPositionDistance;
            else
                waypoint.z -= roadPositionDistance;
            waypoint.y = 0.5f;

        }
        else
        {
            waypoint.x += roadPositionDistance;
            waypoint.y = 0.5f;
        }

        DataScript.waypoints.Add(waypoint);
        DataScript.possibleObstaclePositions.Add(roadPos);
        DataScript.possibleObstaclePositions.Add(waypoint);
        
    }

    void GenerateObstacles()
    {
        int lastIndexOfPossibleObstaclePos = DataScript.possibleObstaclePositions.Count-1;
        float gapBetweenObstacles = Mathf.Floor(lastIndexOfPossibleObstaclePos / levelData.obstaclePositionCount);

        for(int i = (int)gapBetweenObstacles; i < lastIndexOfPossibleObstaclePos-(int)gapBetweenObstacles; i += (int)gapBetweenObstacles)
        {
            obstacleCreator.CreateObstaclesAtPosition(DataScript.possibleObstaclePositions[i], DataScript.possibleObstaclePositions[i + 1]);
        }
    }
}
