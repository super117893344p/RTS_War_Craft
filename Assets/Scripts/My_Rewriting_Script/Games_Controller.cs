using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Games_Controller : MonoBehaviour
{
    public  static Games_Controller Instance {get ;set;}
    public Transform camera_position;
    public Games_Unit current_choice_unit;
    public GameObject[]  unit_panel;
    public GameObject  current_target_place;
    void Awake(){ Instance=this ;}

    public void set_camera_transform_position(Transform t)
    {
         camera_position.SetParent(t);
         camera_position.localPosition=Vector3.zero ;
         camera_position.localRotation=Quaternion.identity ;
    }

    public void show_unit_panel()
    {
        for (int i = 0; i<unit_panel.Length; i++)
        {
             unit_panel[i].SetActive(false);
        }
        unit_panel[current_choice_unit.id].SetActive(true) ;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)&& current_choice_unit)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return ;
            }
            RaycastHit hit;  //射线碰撞到的物体变量
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition) ;
            Physics.Raycast(ray, out hit) ;
            if (hit.collider!=null)
            {
                 Vector3 target_point= hit.point ;
                 target_point.y=-6 ;
                 Character_Player  cc =(Character_Player) current_choice_unit ;
                 switch ( hit.collider.tag)
                 {
                     case "Ground": cc.SetState(UNITSTATE.IDLE);
                         break;
                     case "Character": cc.SetState(UNITSTATE.ATTACK); break;
                     case "Building  " : cc.SetState(UNITSTATE.BUILD) ;
                         Building_Architect building = hit.collider.GetComponent<Building_Architect >();
                         target_point = (current_choice_unit.transform.position-building.transform.position)
                             .normalized *building.area_radius+ hit.collider.transform.position ; break ;
                     case "Mine":  cc.SetState(UNITSTATE.GETGOLD); 
                         Mining mine =hit.collider.GetComponent<Mining>() ;
                         if (mine.get_mine_gold_person_number>=5)
                         {
                              cc.SetState(UNITSTATE.IDLE);
                         }
                         target_point=(current_choice_unit.transform.position-hit.collider.transform.position)
                             .normalized* mine.area_radius+ hit.collider.transform.position; break;
                         default: break;
                 }
                 cc.move_to_target(target_point) ;
                 current_target_place.transform.position=target_point ;
            }
        }
        else if (Input.GetMouseButtonDown(0)&& current_choice_unit)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return ;
            }
            RaycastHit hit ;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition) ;
            Physics.Raycast( ray,out hit );
            if (hit.collider!=null && hit.collider.tag=="Ground")
            {
                current_choice_unit=null ;
                camera_position.position =Vector3.zero ;
                show_panel();
            }


        }

    }

    public void show_panel()
    {
        for (int i = 0; i<unit_panel.Length ; i++)
        {
            unit_panel[i].SetActive(false) ;
        } unit_panel[0].SetActive(true) ;
    }




}
