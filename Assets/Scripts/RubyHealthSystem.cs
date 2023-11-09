using Player.Ruby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Ruby
{
    public class RubyHealthSystem : MonoBehaviour
    {
        //�����������ֵ���������ޣ�
        public int maxHealth = 5;
        //���õ�ǰ����ֵ������ currentHealth
        //C#��֧����������������еķ�װ��������ݳ�Ա�ı���
        //���ݳ�Ա������Ĭ��һ�㶼Ӧ������Ϊ˽�У�ֻ��ͨ����ǰ��ķ��������Խ��з���
        //�����ǹ��еģ�����ͨ��ȡֵ�� get����ֵ�� set �趨��Ӧ�ֶεķ��ʹ������������ܹ����ʣ������ܷ���

        //��������
        public DamageZoneHandle damageZoneHandle;
        public RubyMoveController rubyMoveController;
        public Animator animator;

        //public int currentHealth { get { return _currentHealth; } set { currentHealth = value; } }
        public int currentHealth
        {
            get { return _currentHealth; }//get��Ϊ�ؼ��ֻ�ȡ��ǰ�������󶨵��ֶε�ֵ���������ֵ�Ƕ�Ӧ��
        }
        private int _currentHealth;

        private void Start()
        {
            //��ʼ�����Health
            //��Ϸ�տ�ʼ�������Ѫ
            _currentHealth = maxHealth;

            rubyMoveController = GetComponent<RubyMoveController>();
            damageZoneHandle = GetComponent<DamageZoneHandle>();
        }

        public void ChangeHealth(int amount)
        {
            //�������˶���
            animator.SetTrigger("Hit");

            //����������˺���ʱ������������2��
            if (amount < 0)
            {
                //�жϵ�ǰ����Ƿ����޵�״̬
                if (damageZoneHandle.isInvincible)
                    //�޵�״̬����Ѫ��������ǰ����
                    return;

                    //�������޵�״̬ʱ����ִ������Ĵ���
                    //�����޵�״̬Ϊ��
                    damageZoneHandle.isInvincible = true;
                    //�����޵�ʱ��
                    damageZoneHandle.invincibleTimer = rubyMoveController.timeInvincible;
                
            }
            //���Ʒ��������Ƶ�ǰ����ֵ�ĸ�ֵ��Χ��0-�������ֵ��maxHealth��
            _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
            //�ٿ���̨���������Ϣ
            Debug.Log(_currentHealth + "/" + maxHealth);
        }

    }

}
