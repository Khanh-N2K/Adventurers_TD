using System;
using UnityEngine;
public class Base : MonoBehaviour
{
    [Header("Status")]

    public Status status;

    [Header("Info")]

    public Info info;
    public int currenHeath;

    [Header("Animator")]

    public Animator animator;
    public string idleAnimName = "idle";
    public string moveAnimName = "move";
    public string attackeAnimName = "attack";
    public string dieAnimName = "die";

    [Header("Target")]

    public Base target;

    private void Awake()
    {
        SetUp();
        //SwitchStatus(Status.Idle);
    }

    public virtual void SetUp()
    {
        currenHeath = info.heath;
    }

    public virtual void SwitchStatus(Status status)
    {
        this.status = status;

        switch (status)
        {
            case Status.Idle:
                HandleIdle();
                break;
            case Status.Move:
                HandleMove();
                break;
            case Status.Attack:
                HandleAttack();
                break;
            case Status.Die:
                HandleDie();
                break;
        }
    }

    public virtual void TakeDamage(int damage)
    {

    }

    public virtual void SetTarget(Base target)
    {
        this.target = target;
    }

    public void PlayAnimation(string animName)
    {
        //animator.CrossFade(animName, 0.1f);
    }

    public void MoveTo(Vector3 targetPos)
    {

    }

    protected virtual void StartAttack()
    {

    }

    #region ___ STATUS ___

    public void HandleIdle()
    {
        PlayAnimation(idleAnimName);
    }

    public void HandleMove()
    {
        PlayAnimation(moveAnimName);
    }

    public void HandleAttack()
    {
        PlayAnimation(attackeAnimName);
    }

    public void HandleDie()
    {
        PlayAnimation(dieAnimName);
    }

    #endregion ___
}