// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// public class GameController : MonoBehaviour
// {
//     public static GameController Instance { get; set; }
//     public Unit currentChocieUnit;
//     public Transform cameraTrans;//摄像机Transform引用
//     //设置不同单位的ID，根据不同ID，显示不同单位的面板
//     //0.NONE 1.主城 2.侍僧 3.地穴  4.食尸鬼  5.屠宰场 6.憎恶 7.黑暗祭坛 8.死亡骑士
//     public GameObject[] unitPanels;
//     public GameObject targetGo;
//
//     void Awake()
//     {
//         Instance = this;
//     }
//     /// <summary>
//     /// 设置摄像机位置
//     /// </summary>
//     /// <param name="cameraTransPos">摄像机位置的Transform引用</param>
//     public void SetCameraPos(Transform cameraTransPos)
//     {
//         cameraTrans.SetParent(cameraTransPos);
//         cameraTrans.localPosition = Vector3.zero;
//         cameraTrans.localRotation = Quaternion.identity;
//     }
//     /// <summary>
//     /// 显示当前单位的操作面板
//     /// </summary>
//     public void ShowUnitPanel()
//     {
//         for (int i = 0; i < unitPanels.Length; i++)
//         {
//             unitPanels[i].SetActive(false);
//         }
//         unitPanels[currentChocieUnit.id].SetActive(true);
//     }
//
//     private void Update()
//     {
//         if (Input.GetMouseButtonDown(1)&&currentChocieUnit)
//         {
//             if (EventSystem.current.IsPointerOverGameObject())
//             {
//                 return;
//             }
//             RaycastHit hit;
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             Physics.Raycast(ray,out hit);
//             if (hit.collider!=null)
//             {
//                 Vector3 targetPos= hit.point;
//                 targetPos.y = -6;
//                 //((Character)currentChocieUnit).MoveToTarget(targetPos);
//                 Character cc = (Character)currentChocieUnit;
//                 switch (hit.collider.tag)
//                 {
//                     case "Ground":
//                         cc.SetState(UNITSTATE.IDLE);
//                         break;
//                     case "Mine":
//                         cc.SetState(UNITSTATE.GETGOLD);
//                         Mine minebd = hit.collider.GetComponent<Mine>();
//                         if (minebd.getGoldPersonNum>=5)
//                         {
//                             cc.SetState(UNITSTATE.IDLE);
//                         }
//                         targetPos = (currentChocieUnit.transform.position -
//                             hit.collider.transform.position)
//                             .normalized*minebd.areaRadius*0.8f+hit.collider.transform.position;
//                         break;
//                     case "Character":
//                         cc.SetState(UNITSTATE.ATTACK);
//                         break;
//                     case "Building":
//                         cc.SetState(UNITSTATE.ATTACK);
//                         Building bd = hit.collider.GetComponent<Building>();
//                         targetPos = (currentChocieUnit.transform.position -
//                             hit.collider.transform.position).normalized *
//                             bd.areaRadius + hit.collider.transform.position;
//                         break;
//                     default:
//                         break;
//                 }
//                 cc.MoveToTarget(targetPos);
//                 targetGo.transform.position = targetPos;
//             }
//         }
//         if (currentChocieUnit&&Input.GetMouseButtonDown(0))
//         {
//             if (EventSystem.current.IsPointerOverGameObject())
//             {
//                 return;
//             }
//             RaycastHit hit;
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             Physics.Raycast(ray,out hit);
//             if (hit.collider!=null&&hit.collider.tag=="Ground")
//             {
//                 currentChocieUnit = null;
//                 cameraTrans.position = Vector3.zero;
//                 ShowPanel();
//             }
//
//         }
//     }
//     /// <summary>
//     /// 显示当前选择单位的UI面板
//     /// </summary>
//     /// <param name="id"></param>
//     private void ShowPanel(int id=0)
//     {
//         for (int i = 0; i < unitPanels.Length; i++)
//         {
//             unitPanels[i].SetActive(false);
//         }
//         unitPanels[id].SetActive(true);
//     }
// }
