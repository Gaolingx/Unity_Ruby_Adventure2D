using Player.Ruby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//子弹预制件脚本
public class Projectile : MonoBehaviour
{
    //声明刚体对象
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Awake()
    {
        //获取刚体对象实例
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    //把当前子弹抛射出去的方法
    public void Launch(Vector2 direction, float force)
    {
        //通过刚体对象调用物理系统的 AddForce 方法
        //对游戏对象施加一个力，使其移动
        rigidbody2d.AddForce(direction * force);
    }
    //碰撞事件方法（发生碰撞时自动执行）
    void OnCollisionEnter2D(Collision2D collision)
    {
        //获取齿轮飞弹碰撞到的机器人对象的脚本组件（调用方法前记得获取组件）
        HealthCollectible healthCollectible = collision.collider.GetComponent<HealthCollectible>();
        if (healthCollectible != null)
        {
            healthCollectible.Fix();
        }
        else
        {
            Debug.LogError("healthCollectible值为空");
        }
        //我们还增加了调试日志来了解飞弹触碰到的游戏对象
        Debug.Log($"Projectile Collision with {collision.gameObject}");
        //我们希望子弹碰撞对象后消失，这里需要 Destroy 方法销毁当前子弹游戏对象
        Destroy(gameObject);
    }
}
