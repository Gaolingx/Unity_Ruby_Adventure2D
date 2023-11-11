using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ӵ�Ԥ�Ƽ��ű�
public class Projectile : MonoBehaviour
{
    //�����������
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        //��ȡ�������ʵ��
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    //�ѵ�ǰ�ӵ������ȥ�ķ���
    public void Launch(Vector2 direction, float force)
    {
        //ͨ����������������ϵͳ�� AddForce ����
        //����Ϸ����ʩ��һ������ʹ���ƶ�
        rigidbody2d.AddForce(direction * force);
    }
    //��ײ�¼�������������ײʱ�Զ�ִ�У�
    void OnCollisionEnter2D(Collision2D collision)
    {
        //���ǻ������˵�����־���˽�ɵ�����������Ϸ����
        Debug.Log($"Projectile Collision with {collision.gameObject}");
        //����ϣ���ӵ���ײ�������ʧ��������Ҫ Destroy �������ٵ�ǰ�ӵ���Ϸ����
        Destroy(gameObject);
    }
}
