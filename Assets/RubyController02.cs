using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController02 : MonoBehaviour
{
        // �ڵ�һ��֡����֮ǰ���� Start
        void Start()
        {
            // ֻ�н���ֱͬ����������Ϊ0��������֡��������֡�Ĵ�����Ч
            // ��ֱͬ�������þ�������������Ϸ����˺�ѡ���֡����Ϊ�������Ⱦ������������һͬ��Ⱦ�ģ��������л�������Ⱦ�ģ��ܹ���FPS��������ʾ����ˢ������ͬ��
            QualitySettings.vSyncCount = 0;
            //�趨Ӧ�ó���֡��Ϊ10
            Application.targetFrameRate = 10;
        }

        // ÿ֡����һ�� Update
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 position = transform.position;
            position.x = position.x + 0.1f * horizontal;
            position.y = position.y + 0.1f * vertical;
            transform.position = position;
        }
    
}
