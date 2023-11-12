using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Ruby
{
    public class RubyMoveController : MonoBehaviour
    {
        //声明一个公开的游戏对象 projectilePrefab ，用来获取子弹预制件对象
        public GameObject projectilePrefab;

        //声明刚体对象
        public Rigidbody2D rigidbody2d;
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

        PlayerWeapon playerWeapon;

        //创建一个二维矢量，用来存储 Ruby 静止不动时 看的方向（即面向的方向）
        //与机器人相比，Ruby 可以站立不动、她站立不动时，Move X 和 Y 均为 0，这时状态机就没法获取 Ruby 静止时的朝向
        //所以需要手动设置一个，用来存储静止不动时Ruby的朝向
        public Vector2 lookDirection = new Vector2(1, 0);  //创建二维矢量
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
            playerWeapon = GetComponent<PlayerWeapon>();
        }
        // 每帧调用一次 Update
        void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            //添加发射子弹的逻辑
            //按下键盘上的 c 键，发射飞弹
            if(Input.GetKeyDown(KeyCode.C))
            {
                playerWeapon.Launch();
            }
            //创建一个二维矢量对象来表示 Ruby 移动的数据信息
            Vector2 move = new Vector2(horizontal, vertical);

            //如果二位矢量 move中的 x/y 不为零，表示正在运动
            //将 ruby 面向方向设置为移动方向
            //停止移动，保持以前方向，所以这个 if 结构用于转向时重新赋值面朝方向
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
                //if 条件代表正在移动
            {
                lookDirection.Set(move.x, move.y);  //将现在Ruby的面朝方向设置为移动方向（Ruby朝向移动方向）
                // lookDirection.x = move.x; lookDirection.y = move.y;

                //使向量长度为1，可以将此方法称为 向量的“归一化”方法
                //通常用在表示方向，而非位置的向量上
                //因为blend tree 中表示方向的参数值取值范围是 -1.0 到 1.0,
                //所以一般用 向量作为 Animator.SetFloat 方法的参数时，一般要对向量先进行“归一化”处理
                lookDirection.Normalize();  //将向量长度设置为1
            }

            //传递 Ruby 面朝方向 给 blend tree
            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            //传递 Ruby 速度给 blend tree
            //矢量的 magnitude 属性，用来返回矢量的长度，是一个绝对值
            animator.SetFloat("Speed", move.magnitude);  //辅助判断是否处于移动状态

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

            //healthSystem.ChangeHealth(1);
        }
    }
}
