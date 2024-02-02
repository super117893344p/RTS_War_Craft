using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public enum UNITSTATE
{
    IDLE,
    ATTACK,
    BUILD,
    GETGOLD,
    COLLECTWOOD
}
public class Character_Player : Games_Unit
{
     public Animator animator ;
     public NavMeshAgent Agent;
     public Vector3 target_point ;
     public UNITSTATE player_states;
     public  bool is_moving ; public bool is_having_correct_position;

     public void play_move_animation()
     {
         animator.SetBool("Move",true);
     }

     public void play_attack_animation()
     {
         animator.SetBool("Attack",true );
     }

     public void play_build_animation()
     {
         animator .SetTrigger("Build ") ;
     }

     public void play_get_gold_animation()
     {
         animator .SetBool("GetGold ", true ) ;
     }

     public void stop_animation()
     {
        animator .SetBool("GetGold", false);
        animator.SetBool("Attack",false);
            animator.SetBool("Move",false) ;
     }

     public void random_behavior_params()
     {
         animator.SetFloat("random_behavior_params",Random.Range(0,2)) ;
     }

     public void stop_correct_position()
     {
         is_having_correct_position=true ;
     }
     private void Start()
     {
            InvokeRepeating("random_behavior_params",0,3);
            Invoke( "stop_correct_position",0.05f);
     }

     public void move_to_target(Vector3 pos )
     {
         Agent.isStopped=false ;
         target_point=pos ;
         Agent.SetDestination(target_point) ;
         play_move_animation() ;
     }
     public void reach_target_point()
     {
         stop_animation();
         switch (player_states)
         {
           case UNITSTATE.IDLE:  break;
           case UNITSTATE .ATTACK: play_attack_animation() ;break ;
           case UNITSTATE .BUILD: play_build_animation();break;
           case UNITSTATE .GETGOLD: play_get_gold_animation(); break;
           default:break ;
         }
         stop_moving() ;
     }

     void Update()
     {
         if (is_moving)
         {
             if (Vector3.Distance(this.transform.position,target_point)<=1)
             {
                  reach_target_point() ;
             }
         }
     }
     public void stop_moving()
     {
         Agent .isStopped =true;
         is_moving=false ;
         target_point = this.transform.position ;
     }

     public void SetState(UNITSTATE s)
     {
         stop_animation() ;
         is_moving=true ;
         player_states=s ;
     }




}
