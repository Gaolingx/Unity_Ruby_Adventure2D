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

        //��ҷ����ӵ�
        public void Launch()
        {
            //������ʵ�����ӵ���Ϸ���󣨴����������ʹ��ʵ����������
            GameObject projectileObject = Instantiate(rubyMoveController.projectilePrefab, 
                rubyMoveController.rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            //��ȡ�ӵ���Ϸ����Ľű��������
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            //ͨ���ű���������ӵ��ƶ��ķ���
            //��һ���������ƶ��ķ���ȡ��ֵ������泯�ķ���
            //�ڶ������������������Ҫ�ٶȿ�Щ�����ԼӴ�
            projectile.Launch(rubyMoveController.lookDirection, Projectileforce);
            
        }

    }
}
