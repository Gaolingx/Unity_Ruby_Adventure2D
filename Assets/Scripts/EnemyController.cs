using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //�趨�ƶ��ٶȱ���
    public float speed = 0.1f;
    //����һ��2d������� rigidbody2d��ע������Rigidbody2D��
    public Rigidbody2D rigidbody2d;
    // ���� Vector2(��ά����) ��������ŵ��˵�ǰλ��
    Vector2 position;
    //����һ����ʼ y �������

    //�Ƿ�ֱ�����ƶ���true �Ͱ� y ���ƶ���false �Ͱ� x ���ƶ�
    public bool vertical;

    //�趨һ�� boolֵ����ʼֵ��������˸տ�ʼ�ǡ�������
    public bool broked = true;

    float initY,initX;


    //����һ���ƶ�����ı���
    float direction;
    //����ƶ�����ı���������Ϊ���У������� unity �еķ���
    public float distance = 4;

    Animator animator;

    //����һ�����ԣ�������ȡ������Ч���󣬷��������ô������
    public ParticleSystem smokeEffect;

    // Start is called before the first frame update
    void Start()
    {
        // ��ȡ��Щ������������Ϸ��ʼʱ��ֵ
        rigidbody2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        //��ȡ��ʼλ��
        position = transform.position;
        if (vertical)
        {
            //��ȡ��ʼy���꣬�浽init.Y
            initY = position.y;
        }
        else
        {
            initX = position.x;
        }

        //�趨��ʼ�ƶ�����
        direction = 1.0f;

    }

    //�޸������˵ķ���
    //ʹ�� public ��ԭ��������ϣ����ɵ��ű�һ���������ط������������
    public void Fix()
    {
        //����״̬Ϊ���޸�
        broked = false;
        //�û����˲����ٱ���ײ
        //�����ȡ���Ǹ������ȡ����������Ч��
        rigidbody2d.simulated = false;
        //�����޺�Robot�󶯻�
        animator.SetTrigger("Fixed");

        //���������������
        Destroy(smokeEffect);
    }

    private void FixedUpdate()
    {
        //ע�⣬! ���ſ��Է�ת���ԣ���ˣ���� broken Ϊ true���� !broken ��Ϊ false�����Ҳ���ִ�� return��
        //������޸������ˣ���ֱ���˳� update ����
        //�����ƶ�
        if (!broked)
        {
            return;
        }
        //ͨ�������ƶ��ķ������ã����� fixupdate�����У�0.02��ִ��һ��
        MovePosition();
    }


    // �Զ������ Y ���۷��ƶ����㷨
    private void MovePosition()
    {
        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);

            if (position.y - initY < distance && direction > 0)
            {
                position.y += speed;
            }
            if (position.y - initY >= distance && direction > 0)
            {
                direction = -1.0f;
            }
            if (position.y - initY > 0 && direction < 0)
            {
                position.y -= speed;
            }
            if (position.y - initY <= 0 && direction < 0)
            {
                direction = 1.0f;
            }
        }
        else
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);

            if (position.x - initX < distance && direction > 0)
            {
                position.x += speed;
            }
            if (position.x - initX >= distance && direction > 0)
            {
                direction = -1.0f;
            }
            if (position.x - initX > 0 && direction < 0)
            {
                position.x -= speed;
            }
            if (position.x - initX <= 0 && direction < 0)
            {
                direction = 1.0f;
            }
        }
        //ͨ������ϵͳ�ƶ���Ϸ����
        rigidbody2d.position = position;
    }
}

