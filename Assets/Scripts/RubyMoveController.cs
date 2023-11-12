using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Ruby
{
    public class RubyMoveController : MonoBehaviour
    {
        //����һ����������Ϸ���� projectilePrefab ��������ȡ�ӵ�Ԥ�Ƽ�����
        public GameObject projectilePrefab;

        //�����������
        public Rigidbody2D rigidbody2d;
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

        PlayerWeapon playerWeapon;

        //����һ����άʸ���������洢 Ruby ��ֹ����ʱ ���ķ��򣨼�����ķ���
        //���������ȣ�Ruby ����վ����������վ������ʱ��Move X �� Y ��Ϊ 0����ʱ״̬����û����ȡ Ruby ��ֹʱ�ĳ���
        //������Ҫ�ֶ�����һ���������洢��ֹ����ʱRuby�ĳ���
        public Vector2 lookDirection = new Vector2(1, 0);  //������άʸ��
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
            playerWeapon = GetComponent<PlayerWeapon>();
        }
        // ÿ֡����һ�� Update
        void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            //��ӷ����ӵ����߼�
            //���¼����ϵ� c ��������ɵ�
            if(Input.GetKeyDown(KeyCode.C))
            {
                playerWeapon.Launch();
            }
            //����һ����άʸ����������ʾ Ruby �ƶ���������Ϣ
            Vector2 move = new Vector2(horizontal, vertical);

            //�����λʸ�� move�е� x/y ��Ϊ�㣬��ʾ�����˶�
            //�� ruby ����������Ϊ�ƶ�����
            //ֹͣ�ƶ���������ǰ����������� if �ṹ����ת��ʱ���¸�ֵ�泯����
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
                //if �������������ƶ�
            {
                lookDirection.Set(move.x, move.y);  //������Ruby���泯��������Ϊ�ƶ�����Ruby�����ƶ�����
                // lookDirection.x = move.x; lookDirection.y = move.y;

                //ʹ��������Ϊ1�����Խ��˷�����Ϊ �����ġ���һ��������
                //ͨ�����ڱ�ʾ���򣬶���λ�õ�������
                //��Ϊblend tree �б�ʾ����Ĳ���ֵȡֵ��Χ�� -1.0 �� 1.0,
                //����һ���� ������Ϊ Animator.SetFloat �����Ĳ���ʱ��һ��Ҫ�������Ƚ��С���һ��������
                lookDirection.Normalize();  //��������������Ϊ1
            }

            //���� Ruby �泯���� �� blend tree
            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            //���� Ruby �ٶȸ� blend tree
            //ʸ���� magnitude ���ԣ���������ʸ���ĳ��ȣ���һ������ֵ
            animator.SetFloat("Speed", move.magnitude);  //�����ж��Ƿ����ƶ�״̬

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

            //healthSystem.ChangeHealth(1);
        }
    }
}
