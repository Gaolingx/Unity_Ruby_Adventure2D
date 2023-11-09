using Player.Ruby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectible : MonoBehaviour
{
    public int EnemyRobotDamage;

    //������ײ�¼�����
    //����������У���Ӷ�����˺����߼�
    void OnCollisionEnter2D(Collision2D other)
    {
        //��ȡ�͵��˶�����ײ�������ϵͳ����
        RubyHealthSystem player = other.gameObject.GetComponent<RubyHealthSystem>();  //ע����Ҫ��ȡ��Ϸ����

        if (player != null)
        {
            //��ҽ�ɫ��Ѫ
            player.ChangeHealth(EnemyRobotDamage);
        }
    }
}
