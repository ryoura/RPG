using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum CharaType
{
    None,
    Player,
    Enemy,
}

public class Character : MonoBehaviour
{
    readonly int AnimRequestIDHash = Animator.StringToHash("request_id");

    protected enum AnimationID
    {
        Idle = 0,
        Walk = 1,

        Attack = 10,

        Dead = 110,
    }

    protected NavMeshAgent SelfNavmeshAgent { get; private set; }
    protected Animator SelfAnimator { get; private set; }
    public Transform SelfTransform { get; private set; }

    [SerializeField]
    float moveSpeed = 5.0f;

    /// <summary>
    /// 初期化
    /// </summary>
    public virtual void Init(CharaType charaType)
    {
        CharaType = charaType;

        SelfTransform = transform;
        
        

        //attackHitColliders = GetComponentsInChildren<AttackHitCollider>();
        /*foreach (var attackHit in attackHitColliders)
        {
            attackHit.Init(this);
        }*/
    }

    protected void Move(Vector3 axis)
    {
        SelfNavmeshAgent = GetComponent<NavMeshAgent>();
        SelfNavmeshAgent.Move(axis * moveSpeed * Time.deltaTime);
    }

    protected void PlayAnimation(AnimationID animID)
    {
        SelfAnimator = GetComponent<Animator>();
        SelfAnimator.SetInteger(AnimRequestIDHash, (int)animID);
    }

    private void Update()
    {
        UpdateExecute();
    }

    protected virtual void UpdateExecute() { }

    /// <summary>
    /// キャラタイプ
    /// </summary>
    public CharaType CharaType { get; private set; }

}
