using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //设定移动速度变量
    public float speed = 0.1f;
    //声明一个2d刚体对象 rigidbody2d，注意区分Rigidbody2D类
    public Rigidbody2D rigidbody2d;
    // 声明 Vector2(二维向量) 对象来存放敌人当前位置
    Vector2 position;
    //声明一个初始 y 坐标变量

    //是否垂直方向移动，true 就按 y 轴移动，false 就按 x 轴移动
    public bool vertical;

    //设定一个 bool值，初始值代表机器人刚开始是“坏”的
    public bool broked = true;

    float initY,initX;


    //声明一个移动方向的变量
    float direction;
    //存放移动距离的变量，设置为共有，开放在 unity 中的访问
    public float distance = 4;

    Animator animator;

    //开放一个属性，用来获取烟雾特效对象，方便我们用代码操作
    public ParticleSystem smokeEffect;

    // Start is called before the first frame update
    void Start()
    {
        // 获取这些对象或变量在游戏开始时的值
        rigidbody2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        //获取起始位置
        position = transform.position;
        if (vertical)
        {
            //获取起始y坐标，存到init.Y
            initY = position.y;
        }
        else
        {
            initX = position.x;
        }

        //设定初始移动方向
        direction = 1.0f;

    }

    //修复机器人的方法
    //使用 public 的原因是我们希望像飞弹脚本一样在其他地方调用这个函数
    public void Fix()
    {
        //更改状态为已修复
        broked = false;
        //让机器人不会再被碰撞
        //这里采取的是刚体对象取消物理引擎效果
        rigidbody2d.simulated = false;
        //播放修好Robot后动画
        animator.SetTrigger("Fixed");

        //销毁粒子组件对象
        Destroy(smokeEffect);
    }

    private void FixedUpdate()
    {
        //注意，! 符号可以反转测试，因此，如果 broken 为 true，则 !broken 将为 false，并且不会执行 return。
        //如果已修复机器人，则直接退出 update 方法
        //不再移动
        if (!broked)
        {
            return;
        }
        //通过刚体移动的方法调用，放入 fixupdate方法中，0.02秒执行一次
        MovePosition();
    }


    // 自定义的在 Y 轴折返移动的算法
    private void MovePosition()
    {
        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);

            if (position.y - initY < distance && direction > 0)
            {
                position.y += speed;
            }
            if (position.y - initY >= distance && direction > 0)
            {
                direction = -1.0f;
            }
            if (position.y - initY > 0 && direction < 0)
            {
                position.y -= speed;
            }
            if (position.y - initY <= 0 && direction < 0)
            {
                direction = 1.0f;
            }
        }
        else
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);

            if (position.x - initX < distance && direction > 0)
            {
                position.x += speed;
            }
            if (position.x - initX >= distance && direction > 0)
            {
                direction = -1.0f;
            }
            if (position.x - initX > 0 && direction < 0)
            {
                position.x -= speed;
            }
            if (position.x - initX <= 0 && direction < 0)
            {
                direction = 1.0f;
            }
        }
        //通过刚体系统移动游戏对象
        rigidbody2d.position = position;
    }
}

