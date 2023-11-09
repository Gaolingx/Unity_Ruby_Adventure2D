using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Ruby
{

    public class DamageZoneHandle : MonoBehaviour
    {
        //设置是否无敌的变量
        public bool isInvincible { get { return _isInvincible; } set { _isInvincible = value; } }
        private bool _isInvincible;

        //定义变量，进行无敌时间的计时，无敌时间计时器
        public float invincibleTimer { get { return _invincibleTimer; } set { _invincibleTimer = value; } }
        private float _invincibleTimer;

        // Update is called once per frame
        void Update()
        {

            //判断是否处于无敌状态，来进行计时器的倒计时
            if (_isInvincible)
            {
                //如果无敌，进入倒计时
                _invincibleTimer = _invincibleTimer - Time.deltaTime;
                //可简写为 invincibleTimer -= Time.deltaTime;
                //每次update减去一帧所消耗的时间
                //直到计时器中时间用完
                if (_invincibleTimer < 0)
                {
                    //取消无敌状态
                    _isInvincible = false;

                }
            }

        }
    }
}
