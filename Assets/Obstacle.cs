using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    // 移動速度
    public float speed = 5.0f;

    void Update()
    {
        // 左から右へ移動
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // 画面外へ出たら削除
        if (transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }
    }
}