using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class UIHealthBar : MonoBehaviour
    {
        //�������о�̬��Ա���ԣ���ȡ��ǰѪ������Ҳ����һ����̬��Ѫ��ʵ������
        public static UIHealthBar Instance { get; private set; }  //������������л�ȡ�ö��󣬵�ֻ���ڸö����ڶ�����и�ֵ
        //����UIͼ�ζ���mask����ȡ���ֲ����
        public Image mask;
        //����һ����������¼���ֲ��ʼ����
        float originalSize;

        private void Awake()
        {
            //���þ�̬ʵ��Ϊ��ǰ����󣨵���ģʽ��
            //������޷����Ϊʲô��ô���Ǿ���Ϊ�˻�ȡ���Ψһ��Ѫ������������������Զ����Ѫ����ֵ���и��ģ�����֮�������໹�ǿ��Ա������ֵ
            Instance = this; 
        }

        void Start()
        {
            //��ȡMask���ֲ�ͼ��ĳ�ʼ���ֵ
            originalSize = mask.rectTransform.rect.width;
        }

        //����һ���������������ã����ģ����ڵ� mask ���ֲ�Ŀ�ȣ�Ѫ��Ҳ����֮�仯
        public void SetMaskValue(float value)  //����һ��������������ȡ��ǰѪ����������Ҫ����Ѫ���������������ֲ���
        {
            //���ø��ĵ��� mask ���ֲ�Ŀ�ȣ��������ݴ��ݹ����Ĳ������и���
            mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
        }
    }

