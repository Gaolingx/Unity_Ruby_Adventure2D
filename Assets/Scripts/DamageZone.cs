using Player.Ruby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    //ÿ����Ѫ��
    public int damageNum = -1;
    //�����ڴ������ڵ�ÿһ֡������ô˺������������ڸ���ս���ʱ������һ��
    void OnTriggerStay2D(Collider2D other)
    {   
        RubyHealthSystem healthSystem = other.GetComponent<RubyHealthSystem>();

        if (healthSystem != null)
        {
            healthSystem.ChangeHealth(damageNum);
        }
    }
}
