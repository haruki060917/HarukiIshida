using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    private float positionY;
    private float positionZ;
    private float time;

    // 障害物を生成する間隔（秒）
    public float SpawnInterval = 2.0f;

    // 障害物のプレハブ
    public GameObject obstacle;

    // 障害物を生成
    private void ObstacleGenerate()
    {
        // Y,Z座標をランダムに決定
        positionY = Random.Range(0.5f, 2.0f);
        positionZ = Random.Range(0.0f, 8.0f);

        // 左端から生成
        Vector3 obstaclePosition = new Vector3(-8.0f, positionY, positionZ);

        Instantiate(obstacle, obstaclePosition, Quaternion.identity);
    }

    void Start()
    {
        time = 0.0f;
        ObstacleGenerate();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= SpawnInterval)
        {
            time = 0.0f;
            ObstacleGenerate();
        }
    }
}
