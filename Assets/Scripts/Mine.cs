// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class Mine : Building
// {
//     public Transform[] minePointTrans;
//     public int getGoldPersonNum;
//
//     public Transform GetMinePosTrans()
//     {
//         for (int i = 0; i < minePointTrans.Length; i++)
//         {
//             if (minePointTrans[i].childCount<=0)
//             {
//                 getGoldPersonNum++;
//                 return minePointTrans[i];
//             }
//         }
//         return null;
//     }
//
//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.name.Contains("Acolyte"))
//         {
//             Character character = other.GetComponent<Character>();
//             if (getGoldPersonNum>=5)
//             {
//                 character.SetState(UNITSTATE.IDLE);
//                 character.ReachTargetPoint();
//             }
//             else
//             {
//                 character.ReachTargetPoint();
//                 other.transform.SetParent(GetMinePosTrans());
//                 other.transform.localPosition = Vector3.zero;
//                 other.transform.localRotation = Quaternion.identity;
//             }
//         }
//     }
//
//     private void OnTriggerExit(Collider other)
//     {
//         if (other.name.Contains("Acolyte"))
//         {
//             if (other.transform.parent!=null)
//             {
//                 other.transform.SetParent(null);
//                 getGoldPersonNum--;
//             }
//         }
//     }
// }
