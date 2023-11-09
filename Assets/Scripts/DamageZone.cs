using Player.Ruby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    //每次伤血量
    public int damageNum = -1;
    //刚体在触发器内的每一帧都会调用此函数，而不是在刚体刚进入时仅调用一次
    void OnTriggerStay2D(Collider2D other)
    {   
        RubyHealthSystem healthSystem = other.GetComponent<RubyHealthSystem>();

        if (healthSystem != null)
        {
            healthSystem.ChangeHealth(damageNum);
        }
    }
}
