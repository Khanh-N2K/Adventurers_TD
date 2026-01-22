using System;
using UnityEngine;
public class Base : MonoBehaviour
{
    public Status status;
    public Info info;
    public int currenHeath;
    public AnimationStatus animationStatus;
    public Base target;
    public virtual void SetUp()
    {
        currenHeath = info.heath;
    }
    public virtual void switchStatus(Status status)
    {
        this.status = status;
        animationStatus.SwitchAnim(status);
    }
    public virtual void TakeDamage(int damage)
    {

    }
    public virtual void SetTarget()
    {
        
    }
}