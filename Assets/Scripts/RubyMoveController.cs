using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Ruby
{
    public class RubyMoveController : MonoBehaviour
    {

        //�����������
        Rigidbody2D rigidbody2d;
        //��ȡ�û�����
        float horizontal;
        float vertical;
        //ע�⣺���Ҫ�ڶ���������������ͬ�ı������������Ҫ�ڷ���������

        // ���ٶȱ�¶������ʹ��ɵ�
        public float speed = 0.1f;
        //��������
        public RubyHealthSystem healthSystem;

        //����һ�������������������
        Animator animator;
        //����һ����άʸ���������洢 Ruby ��ֹ����ʱ ���ķ��򣨼�����ķ���
        //���������ȣ�Ruby ����վ����������վ������ʱ��Move X �� Y ��Ϊ 0����ʱ״̬����û����ȡ Ruby ��ֹʱ�ĳ���
        //������Ҫ�ֶ�����һ���������洢��ֹ����ʱRuby�ĳ���
        Vector2 lookDirection = new Vector2(1, 0);  //������άʸ��
        Vector2 move;  //�ƶ�ʸ��

        //��������޵е�ʱ����
        public float timeInvincible = 2.0f;

        //ֻ������Ϸ��ʼ֮ǰ��ȡ��ǰ��Ϸ����ĸ������������Ҫһֱ��ȡ
        private void Start()
        {
            //��ȡ�������
            animator = GetComponent<Animator>();
            rigidbody2d = GetComponent<Rigidbody2D>();
            healthSystem = GetComponent<RubyHealthSystem>();
        }
        // ÿ֡����һ�� Update
        void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");


        }

        //Update()�����ڲ�ͬ֡����ִ�д�����һ��������ϣ���Թ̶���Ƶ��ִ��ĳЩ������Ҫ�õ�FixedUpdate()������ʹ������㱣���ȶ�
        //�̶�ʱ����ִ�еĸ��·���
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
