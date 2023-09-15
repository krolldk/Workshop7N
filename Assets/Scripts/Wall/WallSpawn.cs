using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    public Target prefab;
    public int width = 20;
    public int height = 5;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWall();
    }

    void SpawnWall()
    {
        Vector3 spawnPoint = transform.position;
        for(int i=0; i<height; i++)
        {
            spawnPoint.x = transform.position.x;
            for(int j=0; j<width; j++)
            {
                Target t = Instantiate<Target>(prefab, spawnPoint, transform.rotation);
                spawnPoint.x += 2f;
            }
            spawnPoint.y += 2f;
        }
    }

}
