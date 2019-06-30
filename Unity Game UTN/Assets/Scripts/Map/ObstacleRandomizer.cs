using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizer : MonoBehaviour
{
    // Publics
    public float spawnRate = 1;
    // Prefabs
    public Transform wall;
    public float wallProb; //Probabilities
    public Transform middleWall;
    public float middleWallProb; //Probabilities
    public Transform doubleWall;
    public float doubleWallProb; //Probabilities
    public Transform bigWall;
    public float bigWallProb; //Probabilities


    // Privates
    private float nextSpawnTime;
    private Transform objectTransform;

    void Start()
    {
        nextSpawnTime = spawnRate;
        objectTransform = GetComponent<Transform>();
        verifyProbs();
    }

    void Update()
    {
        if (shouldSpawn())
        {
            spawnObstacle();
        }
    }

    // Spawnea Aleatoriamente 1 obstaculo, basandose en las probabilidades asignadas a cada uno
    private void spawnObstacle()
    {
        float value = Random.Range(1f, 100f);
        float max = wallProb;

        if (value <= max)
        {
            Instantiate(wall, randomSide(wall.position), Quaternion.identity, objectTransform);
        } else if (value > max && value <= (max += middleWallProb))
        {
            Instantiate(middleWall, randomizeWall(middleWall.position), Quaternion.identity, objectTransform);
        } else if (value > max && value <= (max += doubleWallProb))
        {
            Instantiate(doubleWall, new Vector3(doubleWall.position.x, doubleWall.position.y, doubleWall.position.z), Quaternion.identity, objectTransform);
            Instantiate(doubleWall, new Vector3(-doubleWall.position.x, doubleWall.position.y, doubleWall.position.z), Quaternion.identity, objectTransform);
        } else if (value > max && value <= (max += bigWallProb))
        {
            Instantiate(bigWall, randomSide(bigWall.position), Quaternion.identity, objectTransform);
        }

        nextSpawnTime = Time.time + spawnRate;
    }

    private Vector3 randomizeWall(Vector3 position)
    {
        position = new Vector3(Random.Range(position.x, -position.x), position.y, position.z);

        return position;
    }

    // Devuelve 1 o -1 para cambiar el lado del obstaculo
    private Vector3 randomSide(Vector3 position)
    {
        int random = (int)Mathf.Round(Random.Range(0f, 1f));

        if (random == 0)
            position = new Vector3(position.x * -1, wall.position.y, wall.position.z);

        return position;
    }

    private bool shouldSpawn() => Time.time >= nextSpawnTime;

    // Verifica que el porcentaje de las probabiliddades no supere el 100 %
    private void verifyProbs()
    {
        float value = wallProb + middleWallProb + doubleWallProb + bigWallProb;

        if (value > 100)
        {
            Debug.LogError("La suma de las probabilidades no debe superar el 100%");
        }
    }
}
