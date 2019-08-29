using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public GameObject[] obstacles;

   
    public void CreateObstaclesAtPosition(Vector3 position1, Vector3 position2)
    {
        if (position1.x == position2.x)
            CreateObstaclesAlongXAxis(position1);
        else if(position1.z == position2.z)
            CreateObstaclesAlongZAxis(position1);
    }

    public void CreateObstaclesAlongXAxis(Vector3 position)
    {
        Vector3 increments = new Vector3(3f, 0.5f, Mathf.Round(Random.Range(6f, 10f)));

        PutObstacles(position, increments, true);
        
    }

    public void CreateObstaclesAlongZAxis(Vector3 position)
    {
        
        Vector3 increments = new Vector3(Mathf.Round(Random.Range(6f, 10f)), 0.5f, 3f);

        PutObstacles(position, increments, false);
    }

    void PutObstacles(Vector3 position, Vector3 increments,bool isAlongXAxis)
    {
        int obstaclePutStyle = Random.Range(1, 6);
        int obstacleSelector = Random.Range(0, obstacles.Length - 1);
        float obstacleScale = Random.Range(0.5f, 0.8f);
        Vector3 obstacleScalerVec = new Vector3(obstacleScale, obstacleScale, obstacleScale);

        switch (obstaclePutStyle)
        {
            case 1:
                for (float xRange = increments.x * -1; xRange <= increments.x; xRange++)
                {
                    for (float yRange = 0.5f; yRange <= increments.y; yRange += 0.5f)
                    {
                        for (float zRange = increments.z * -1; zRange <= increments.z; zRange++)
                        {
                            GameObject obstacle = Instantiate(obstacles[obstacleSelector], new Vector3(position.x + xRange, 0.5f + yRange, position.z + zRange), Quaternion.identity);
                            obstacle.transform.localScale = obstacleScalerVec;
                        }
                    }
                }
                break;
            case 2:
                for (float xRange = increments.x * -1; xRange <= increments.x; xRange++)
                {
                    for (float yRange = 0.5f; yRange <= increments.y * 2; yRange += 0.5f)
                    {
                        for (float zRange = increments.z * -1; zRange <= increments.z; zRange++)
                        {
                            GameObject obstacle = Instantiate(obstacles[obstacleSelector], new Vector3(position.x + xRange, 0.5f + yRange, position.z + zRange), Quaternion.identity);
                            obstacle.transform.localScale = obstacleScalerVec;
                        }
                    }
                }
                break;
            case 3:
                if (isAlongXAxis)
                {
                    for (float xRange = increments.x * -1; xRange <= increments.x; xRange++)
                    {
                        for (float yRange = 0.5f; yRange <= increments.y * 2; yRange += 0.5f)
                        {
                            for (float zRange = increments.z * -1; zRange <= increments.z; zRange++)
                            {
                                if(zRange < -2f || zRange > 2f)
                                {
                                    GameObject obstacle = Instantiate(obstacles[obstacleSelector], new Vector3(position.x + xRange, 0.5f + yRange, position.z + zRange), Quaternion.identity);
                                    obstacle.transform.localScale = obstacleScalerVec;
                                }
                                    
                            }
                        }
                    }
                }
                else
                {
                    for (float xRange = increments.x * -1; xRange <= increments.x; xRange++)
                    {
                        for (float yRange = 0.5f; yRange <= increments.y * 2; yRange += 0.5f)
                        {
                            for (float zRange = increments.z * -1; zRange <= increments.z; zRange++)
                            {
                                if(xRange < -2f || xRange > 2f)
                                {
                                    GameObject obstacle = Instantiate(obstacles[obstacleSelector], new Vector3(position.x + xRange, 0.5f + yRange, position.z + zRange), Quaternion.identity);
                                    obstacle.transform.localScale = obstacleScalerVec;
                                }
                                    
                            }
                        }
                    }
                }
                
                break;
            case 4:
                if (isAlongXAxis)
                {
                    for (float xRange = increments.x * -1; xRange <= increments.x; xRange++)
                    {
                        for (float yRange = 0.5f; yRange <= increments.y * 2; yRange += 0.5f)
                        {
                            for (float zRange = increments.z * -1; zRange <= increments.z; zRange++)
                            {
                                if (xRange < -1f || xRange > 1f)
                                {
                                    GameObject obstacle = Instantiate(obstacles[obstacleSelector], new Vector3(position.x + xRange, 0.5f + yRange, position.z + zRange), Quaternion.identity);
                                    obstacle.transform.localScale = obstacleScalerVec;
                                }
                                    
                            }
                        }
                    }
                }
                else
                {
                    for (float xRange = increments.x * -1; xRange <= increments.x; xRange++)
                    {
                        for (float yRange = 0.5f; yRange <= increments.y * 2; yRange += 0.5f)
                        {
                            for (float zRange = increments.z * -1; zRange <= increments.z; zRange++)
                            {
                                if (zRange < -1f || zRange > 1f)
                                {
                                    GameObject obstacle = Instantiate(obstacles[obstacleSelector], new Vector3(position.x + xRange, 0.5f + yRange, position.z + zRange), Quaternion.identity);
                                    obstacle.transform.localScale = obstacleScalerVec;
                                }
                                    
                            }
                        }
                    }
                }

                break;
            case 5:
                for (float xRange = increments.x * -1; xRange <= increments.x; xRange++)
                {
                    for (float yRange = 0.5f; yRange <= increments.y * 2; yRange += 0.5f)
                    {
                        for (float zRange = increments.z * -1; zRange <= increments.z; zRange++)
                        {
                            if (xRange == zRange)
                            {
                                GameObject obstacle = Instantiate(obstacles[obstacleSelector], new Vector3(position.x + xRange, 0.5f + yRange, position.z + zRange), Quaternion.identity);
                                obstacle.transform.localScale = obstacleScalerVec;
                            }

                        }
                    }
                }
                break;
        }
        
    }
}
