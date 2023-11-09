using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController01 : MonoBehaviour
{
    // ÿ֡����һ�� Update
    // ����Ϸ����ÿ֡���� 0.1
    void Update()
    {
        // ��ȡˮƽ���룬�����󣬻��� -1.0 f ; �����ң����� 1.0 f
        float horizontal = Input.GetAxis("Horizontal");
        // ��ȡ��ֱ���룬�����£����� -1.0 f ; �����ϣ����� 1.0 f
        float vertical = Input.GetAxis("Vertical");

        // ��ȡ����ǰλ��
        // ��ά����position = ���嵱ǰλ�� + �ƶ�λ��(ÿִ֡��update��������ִ��һ��) + �ƶ��ķ���
        Vector2 position = transform.position;
        // ��Ӧ����������λ��
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * vertical;
        // ��λ�ø���Ϸ����
        transform.position = position;
    }
}
