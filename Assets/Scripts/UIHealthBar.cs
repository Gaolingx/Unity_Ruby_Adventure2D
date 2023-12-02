using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class UIHealthBar : MonoBehaviour
    {
        //声明公有静态成员属性，获取当前血条本身，也就是一个静态的血条实例对象
        public static UIHealthBar Instance { get; private set; }  //可在任意对象中获取该对象，但只能在该对象内对其进行赋值
        //创建UI图形对象mask，获取遮罩层对象
        public Image mask;
        //设置一个变量，记录遮罩层初始长度
        float originalSize;

        private void Awake()
        {
            //设置静态实例为当前类对象（单例模式）
            //如果你无法理解为什么这么做那就是为了获取这个唯一的血条，在其他组件都可以对这个血条的值进行更改，更改之后到其他类还是可以保持这个值
            Instance = this; 
        }

        void Start()
        {
            //获取Mask遮罩层图像的初始宽度值
            originalSize = mask.rectTransform.rect.width;
        }

        //创建一个方法，用来设置（更改）现在的 mask 遮罩层的宽度，血量也会随之变化
        public void SetMaskValue(float value)  //设置一个参数，用来获取当前血量，我们需要根据血量多少来更改遮罩层宽度
        {
            //设置更改的是 mask 遮罩层的宽度，并且依据传递过来的参数进行更改
            mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
        }
    }

