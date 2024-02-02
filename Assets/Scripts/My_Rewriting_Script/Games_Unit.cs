using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Games_Unit : MonoBehaviour
{
    public int id ;
    public Transform camera_transform_location ;

    public void OnMouseDown() //MonoBehaviour 提供的鼠标点击事件
    {
      Games_Controller.Instance.current_choice_unit= this;
      Games_Controller.Instance.set_camera_transform_position(camera_transform_location);
      Games_Controller.Instance. show_unit_panel() ;
    }



}
