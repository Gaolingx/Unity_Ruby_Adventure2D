using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // 每帧调用一次 Update
    // 让游戏对象每帧右移 0.1个单位(每一个方格代表1个单位)
    void Update()
    {
        // 创建一个 Vector2 对象 position，用来获取当前对象的位置
        Vector2 position = transform.position;
        // 更改 position 的 x 坐标值，让其 加上 0.1
        position.x = position.x + 0.1f;
        // 更新当前对象的位置到新位置
        transform.position = position;
    }
}
