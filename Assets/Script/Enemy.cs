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

    public GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // ターゲットの位置を目的地に設定する。
        agent.destination = target.transform.position;
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

    /// <summary>
    /// 切り替えるアクションが同じの時に呼ばれる
    /// </summary>
    /// <param name="actionState"></param>
    protected virtual void OnSameActionState(ActionState actionState)
    {

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

    protected virtual void OnStartActionState(ActionState actionState)
    {
        switch (actionState)
        {
            case ActionState.Idle:
                PlayAnimation(AnimationID.Idle);
                break;
            case ActionState.Dead:
                PlayAnimation(AnimationID.Dead);
                break;
        }
    }

    protected override void UpdateExecute()
    {

    }

    protected override void OnIdle()
    {
        ChangeActionState(ActionState.Idle);
    }

    protected ActionState GetActionState()
    {
        return actionState;
    }
}
