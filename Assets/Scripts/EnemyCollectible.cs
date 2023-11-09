using Player.Ruby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectible : MonoBehaviour
{
    public int EnemyRobotDamage;

    //刚体碰撞事件方法
    //在这个方法中，添加对玩家伤害的逻辑
    void OnCollisionEnter2D(Collision2D other)
    {
        //获取和敌人对象碰撞玩家生命系统对象
        RubyHealthSystem player = other.gameObject.GetComponent<RubyHealthSystem>();  //注意先要获取游戏对象

        if (player != null)
        {
            //玩家角色掉血
            player.ChangeHealth(EnemyRobotDamage);
        }
    }
}
