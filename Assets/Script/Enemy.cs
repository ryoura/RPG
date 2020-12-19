using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    protected enum ActionState
    {
        None,

        Idle,
        Walk,
        Attack,

        Dead,
    }

    ActionState actionState = ActionState.None;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

   

    public override void Init(CharaType charaType)
    {
        base.Init(charaType);

    }

    /// <summary>
    /// 弾に当たったら消える
    /// </summary>
    /// <param name="collision">弾</param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shell"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    protected void ChangeActionState(ActionState actionState)
    {
        OnFinishActionState(this.actionState);

        this.actionState = actionState;

        OnStartActionState(this.actionState);
    }

    protected virtual void OnFinishActionState(ActionState actionState)
    {

    }

    protected  void OnStartActionState(ActionState actionState)
    {
        switch (actionState)
        {
            case ActionState.Idle:
                PlayAnimation(AnimationID.Idle);
                break;
            case ActionState.Walk:
                PlayAnimation(AnimationID.Walk);
                break;
            case ActionState.Dead:
                PlayAnimation(AnimationID.Dead);
                break;
        }
    }


    protected ActionState GetActionState()
    {
        return actionState;
    }
}
