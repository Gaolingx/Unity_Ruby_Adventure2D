using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Ruby
{
    public class PlayerWeapon : MonoBehaviour
    {
        public float Projectileforce = 300;

        public RubyMoveController rubyMoveController;
        // Start is called before the first frame update
        void Start()
        {
            rubyMoveController = GetComponent<RubyMoveController>();
        }

        //玩家发射子弹
        public void Launch()
        {
            //创建并实例化子弹游戏对象（创建对象必须使用实例化方法）
            GameObject projectileObject = Instantiate(rubyMoveController.projectilePrefab, 
                rubyMoveController.rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            //获取子弹游戏对象的脚本组件对象
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            //通过脚本对象调用子弹移动的方法
            //第一个参数是移动的方向，取的值是玩家面朝的方向
            //第二个参数是力，如果想要速度快些，可以加大
            projectile.Launch(rubyMoveController.lookDirection, Projectileforce);
            
        }

    }
}
