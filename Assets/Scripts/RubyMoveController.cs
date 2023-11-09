using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Ruby
{
    public class RubyMoveController : MonoBehaviour
    {

        //声明刚体对象
        Rigidbody2D rigidbody2d;
        //获取用户输入
        float horizontal;
        float vertical;
        //注意：如果要在多个方法里面调用相同的变量，则变量需要在方法外声明

        // 将速度暴露出来，使其可调
        public float speed = 0.1f;
        //声明对象
        public RubyHealthSystem healthSystem;

        //声明一个动画管理者组件对象
        Animator animator;
        //创建一个二维矢量，用来存储 Ruby 静止不动时 看的方向（即面向的方向）
        //与机器人相比，Ruby 可以站立不动、她站立不动时，Move X 和 Y 均为 0，这时状态机就没法获取 Ruby 静止时的朝向
        //所以需要手动设置一个，用来存储静止不动时Ruby的朝向
        Vector2 lookDirection = new Vector2(1, 0);  //创建二维矢量
        Vector2 move;  //移动矢量

        //设置玩家无敌的时间间隔
        public float timeInvincible = 2.0f;

        //只需在游戏开始之前获取当前游戏对象的刚体组件，不需要一直获取
        private void Start()
        {
            //获取组件对象
            animator = GetComponent<Animator>();
            rigidbody2d = GetComponent<Rigidbody2D>();
            healthSystem = GetComponent<RubyHealthSystem>();
        }
        // 每帧调用一次 Update
        void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");


        }

        //Update()方法在不同帧率下执行次数不一样，我们希望以固定的频率执行某些代码需要用到FixedUpdate()方法，使物理计算保持稳定
        //固定时间间隔执行的更新方法
        private void FixedUpdate()
        {
            Vector2 position = transform.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;
            //rigidbody2d.position = position;
            rigidbody2d.MovePosition(position);

            /*healthSystem.ChangeHealth(1);*/
        }
    }
}
