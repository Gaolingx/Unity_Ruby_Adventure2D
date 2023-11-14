using Player.Ruby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class HealthCollectible : MonoBehaviour
{
    //��ݮ�ӵ�Ѫ��
    public int amount = 1;

    //������¼��ײ����
    int collideCount;

    private EnemyController enemyController;
    //��Ӵ���������ײ�¼���ÿ����ײ��������ʱ�򶼻ἤ������ķ���ִ���߼�
    private void OnTriggerEnter2D(Collider2D other)
    {
        //collideCount = collideCount + 1;
        collideCount++;
        Debug.Log($"�͵�ǰ���巢����ײ�Ķ�����: {other},��ǰ�ǵ�{collideCount}����ײ��");

        //��ȡRuby��Ϸ����Ľű��������
        RubyHealthSystem healthSystem = other.GetComponent<RubyHealthSystem>();
        if (healthSystem != null)
        {
            if (healthSystem.currentHealth < healthSystem.maxHealth)
            {
                //��������ֵ
                healthSystem.ChangeHealth(amount);
                //���ٵ�ǰ��Ϸ���󣬿����ò�ݮ���Ե�����ʧ
                DestroyObject(gameObject);
            }
        }
        else
        {
            Debug.LogError("����healthSystem ��Ϸ���δ��ȡ����");
        }

    }
    //�޸������˵ķ���
    //ʹ�� public ��ԭ��������ϣ����ɵ��ű�һ���������ط������������
    public void Fix()
    {
        //����״̬Ϊ���޸�
        enemyController.broked = false;
        //�û����˲����ٱ���ײ
        //�����ȡ���Ǹ������ȡ����������Ч��
        enemyController.rigidbody2d.simulated = false;
    }
}
