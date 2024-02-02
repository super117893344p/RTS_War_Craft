// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;
//
// public class Character : Unit
// {
//     public Animator animator;
//     public NavMeshAgent meshAgent;
//     public Vector3 targetPos;
//     public UNITSTATE currentState;
//     public bool isMoving;
//     private bool hasCorrectPos;
//
//     public void PlayMoveAnimation()
//     {
//         animator.SetBool("Move",true);
//     }
//
//     public void PlayAttackAnimation()
//     {
//         animator.SetBool("Attack", true);
//     }
//
//     public void PlayBuildAnimation()
//     {
//         animator.SetTrigger("Build");
//     }
//
//     public void PlayGetGoldAnimation()
//     {
//         animator.SetBool("GetGold",true);
//     }
//
//     public void StopAnimations()
//     {
//         animator.SetBool("Move", false);
//         animator.SetBool("Attack", false);
//         animator.SetBool("GetGold", false);
//     }
//
//     public void RandomBehaviourParam()
//     {
//         animator.SetFloat("RandomBehaviourParam", Random.Range(0,2));
//     }
//
//     private void Start()
//     {
//         InvokeRepeating("RandomBehaviourParam",0,3);
//         Invoke("StopCorrecting",0.05f);
//     }
//
//     private void StopCorrecting()
//     {
//         hasCorrectPos = true;
//     }
//
//     /// <summary>
//     /// 移动到目标点
//     /// </summary>
//     /// <param name="pos"></param>
//     public void MoveToTarget(Vector3 pos)
//     {
//         meshAgent.isStopped = false;
//         targetPos = pos;
//         meshAgent.SetDestination(targetPos);
//         PlayMoveAnimation();
//     }
//
//     private void Update()
//     {
//         //Debug.Log(Vector3.Distance(transform.position, targetPos));
//         if (isMoving)
//         {
//             if (Vector3.Distance(transform.position, targetPos) <= 1)
//             {
//                 //meshAgent.isStopped = true;
//                 //StopAnimations();
//                 ReachTargetPoint();
//             }
//         }
//     }
//     /// <summary>
//     /// 到达目标点
//     /// </summary>
//     public void ReachTargetPoint()
//     {
//         StopAnimations();
//         switch (currentState)
//         {
//             case UNITSTATE.IDLE:
//                 break;
//             case UNITSTATE.ATTACK:
//                 PlayAttackAnimation();
//                 break;
//             case UNITSTATE.BUILD:
//                 PlayBuildAnimation();
//                 break;
//             case UNITSTATE.GETGOLD:
//                 PlayGetGoldAnimation();
//                 break;
//             case UNITSTATE.COLLECTWOOD:
//                 break;
//             default:
//                 break;
//         }
//         StopMoving();
//     }
//     /// <summary>
//     /// 停止移动
//     /// </summary>
//     private void StopMoving()
//     {
//         meshAgent.isStopped = true;
//         isMoving = false;
//         targetPos = transform.position;
//     }
//     /// <summary>
//     /// 设置行为状态
//     /// </summary>
//     // public void SetState(UNITSTATE us)
//     // {
//     //     StopAnimations();
//     //     currentState = us;
//     //     isMoving = true;
//     // }
//
//     private void OnTriggerEnter(Collider other)
//     {
//         if (!hasCorrectPos)
//         {
//             if (LayerMask.LayerToName(other.gameObject.layer) == "Unit")
//             {
//                 hasCorrectPos = true;
//                 transform.position += new Vector3(Random.Range(1f, 2f), 0, Random.Range(1f, 2f));
//             }
//         }
//
//     }
// }
//
// public enum UNITSTATE
// {
//     IDLE,
//     ATTACK,
//     BUILD,
//     GETGOLD,
//     COLLECTWOOD
// }
