using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController02 : MonoBehaviour
{
        // 在第一次帧更新之前调用 Start
        void Start()
        {
            // 只有将垂直同步计数设置为0，才能锁帧，否则锁帧的代码无效
            // 垂直同步的作用就是显著减少游戏画面撕裂、跳帧，因为画面的渲染不是整个画面一同渲染的，而是逐行或逐列渲染的，能够让FPS保持与显示屏的刷新率相同。
            QualitySettings.vSyncCount = 0;
            //设定应用程序帧数为10
            Application.targetFrameRate = 10;
        }

        // 每帧调用一次 Update
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 position = transform.position;
            position.x = position.x + 0.1f * horizontal;
            position.y = position.y + 0.1f * vertical;
            transform.position = position;
        }
    
}
