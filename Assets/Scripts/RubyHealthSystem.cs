using Player.Ruby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Ruby
{
    public class RubyHealthSystem : MonoBehaviour
    {
        //设置最大生命值（生命上限）
        public int maxHealth = 5;
        //设置当前生命值的属性 currentHealth
        //C#中支持面向对象程序设计中的封装概念，对数据成员的保护
        //数据成员变量，默认一般都应该设置为私有，只能通过当前类的方法或属性进行访问
        //属性是公有的，可以通过取值器 get、赋值器 set 设定对应字段的访问规则，满足规则才能够访问，否则不能访问

        //声明对象
        public DamageZoneHandle damageZoneHandle;
        public RubyMoveController rubyMoveController;
        public Animator animator;

        //public int currentHealth { get { return _currentHealth; } set { currentHealth = value; } }
        public int currentHealth
        {
            get { return _currentHealth; }//get作为关键字获取当前属性所绑定的字段的值，与下面的值是对应的
        }
        private int _currentHealth;

        private void Start()
        {
            //初始化玩家Health
            //游戏刚开始，玩家满血
            _currentHealth = maxHealth;

            rubyMoveController = GetComponent<RubyMoveController>();
            damageZoneHandle = GetComponent<DamageZoneHandle>();
        }

        public void ChangeHealth(int amount)
        {
            //播放受伤动画
            animator.SetTrigger("Hit");

            //假设玩家受伤害的时间间隔，必须是2秒
            if (amount < 0)
            {
                //判断当前玩家是否处于无敌状态
                if (damageZoneHandle.isInvincible)
                    //无敌状态不伤血，跳出当前函数
                    return;

                    //当不是无敌状态时，会执行下面的代码
                    //重置无敌状态为真
                    damageZoneHandle.isInvincible = true;
                    //重置无敌时间
                    damageZoneHandle.invincibleTimer = rubyMoveController.timeInvincible;
                
            }
            //限制方法，限制当前生命值的赋值范围：0-最大生命值（maxHealth）
            _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
            //再控制台输出生命信息
            Debug.Log(_currentHealth + "/" + maxHealth);
        }

    }

}
