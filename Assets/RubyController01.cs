using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController01 : MonoBehaviour
{
    // 每帧调用一次 Update
    // 让游戏对象每帧右移 0.1
    void Update()
    {
        // 获取水平输入，按向左，会获得 -1.0 f ; 按向右，会获得 1.0 f
        float horizontal = Input.GetAxis("Horizontal");
        // 获取垂直输入，按向下，会获得 -1.0 f ; 按向上，会获得 1.0 f
        float vertical = Input.GetAxis("Vertical");

        // 获取对象当前位置
        // 二维向量position = 物体当前位置 + 移动位置(每帧执行update方法都会执行一次) + 移动的方向
        Vector2 position = transform.position;
        // 响应操作，更改位置
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * vertical;
        // 新位置给游戏对象
        transform.position = position;
    }
}
