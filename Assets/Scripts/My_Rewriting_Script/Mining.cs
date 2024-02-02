using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
public class Mining : Building_Architect
{
    public  Transform [] mine_point_position ;
    public int get_mine_gold_person_number=0 ;

    public Transform get_mine_point_position()
    {
        for (int i = 0; i< mine_point_position.Length; i++)
        {
            if ( mine_point_position[i].childCount<=0)
            {
                get_mine_gold_person_number++;
                return mine_point_position[i] ;
            }
        }
             return null;
    }

    void OnTriggerEnter(Collider other) //unity 处理碰撞重叠的函数
    {
        if (other.name.Contains("Acolyte"))
        {
            Character_Player character =other.GetComponent<Character_Player>() ;
            if (get_mine_gold_person_number>=5)
            {
                character.SetState(UNITSTATE.IDLE);
                character.reach_target_point();
            }
            else
            {
                character .reach_target_point() ;
                other.transform.SetParent(get_mine_point_position());
                other.transform.localPosition=Vector3.zero;
                other .transform .localRotation=Quaternion.identity;

            }
        }
    }

    private void OnTriggerExit(Collider other )
    {
        if (other.name.Contains("Acolyte"))
        {
            if (other.transform.parent!=null )
            {
                get_mine_gold_person_number--;
                other .transform.SetParent(null);
            }
        }
    }







}
