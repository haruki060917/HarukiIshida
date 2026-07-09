using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    // 移動速度
    public float speed = 3.0f;

    // 左右の移動範囲
    public float leftLimit = -8.0f;
    public float rightLimit = 8.0f;

    // 移動方向（1 = 右、-1 = 左）
    private int direction = 1;

    void Update()
    {
        // 左右へ移動
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // 右端に到達したら左へ
        if (transform.position.x >= rightLimit)
        {
            direction = -1;
        }

        // 左端に到達したら右へ
        if (transform.position.x <= leftLimit)
        {
            direction = 1;
        }
    }
}