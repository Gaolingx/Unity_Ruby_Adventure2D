using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Ruby
{

    public class DamageZoneHandle : MonoBehaviour
    {
        //�����Ƿ��޵еı���
        public bool isInvincible { get { return _isInvincible; } set { _isInvincible = value; } }
        private bool _isInvincible;

        //��������������޵�ʱ��ļ�ʱ���޵�ʱ���ʱ��
        public float invincibleTimer { get { return _invincibleTimer; } set { _invincibleTimer = value; } }
        private float _invincibleTimer;

        // Update is called once per frame
        void Update()
        {

            //�ж��Ƿ����޵�״̬�������м�ʱ���ĵ���ʱ
            if (_isInvincible)
            {
                //����޵У����뵹��ʱ
                _invincibleTimer = _invincibleTimer - Time.deltaTime;
                //�ɼ�дΪ invincibleTimer -= Time.deltaTime;
                //ÿ��update��ȥһ֡�����ĵ�ʱ��
                //ֱ����ʱ����ʱ������
                if (_invincibleTimer < 0)
                {
                    //ȡ���޵�״̬
                    _isInvincible = false;

                }
            }

        }
    }
}
