using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // ÿ֡����һ�� Update
    // ����Ϸ����ÿ֡���� 0.1����λ(ÿһ���������1����λ)
    void Update()
    {
        // ����һ�� Vector2 ���� position��������ȡ��ǰ�����λ��
        Vector2 position = transform.position;
        // ���� position �� x ����ֵ������ ���� 0.1
        position.x = position.x + 0.1f;
        // ���µ�ǰ�����λ�õ���λ��
        transform.position = position;
    }
}
