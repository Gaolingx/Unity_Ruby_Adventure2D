using Player.Ruby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class HealthCollectible : MonoBehaviour
{
    //草莓加的血量
    public int amount = 1;

    //用来记录碰撞次数
    int collideCount;

    private EnemyController enemyController;
    //添加触发器的碰撞事件，每次碰撞触发器的时候都会激活里面的方法执行逻辑
    private void OnTriggerEnter2D(Collider2D other)
    {
        //collideCount = collideCount + 1;
        collideCount++;
        Debug.Log($"和当前物体发生碰撞的对象是: {other},当前是第{collideCount}次碰撞！");

        //获取Ruby游戏对象的脚本组件对象
        RubyHealthSystem healthSystem = other.GetComponent<RubyHealthSystem>();
        if (healthSystem != null)
        {
            if (healthSystem.currentHealth < healthSystem.maxHealth)
            {
                //更改生命值
                healthSystem.ChangeHealth(amount);
                //销毁当前游戏对象，可以让草莓被吃掉，消失
                DestroyObject(gameObject);
            }
        }
        else
        {
            Debug.LogError("错误：healthSystem 游戏组件未获取到！");
        }

    }
    //修复机器人的方法
    //使用 public 的原因是我们希望像飞弹脚本一样在其他地方调用这个函数
    public void Fix()
    {
        //更改状态为已修复
        enemyController.broked = false;
        //让机器人不会再被碰撞
        //这里采取的是刚体对象取消物理引擎效果
        enemyController.rigidbody2d.simulated = false;
    }
}
