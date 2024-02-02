using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class  Building_Architect : Games_Unit
{
    public float area_radius;
    private SphereCollider sc;
    private NavMeshObstacle  nav;

    void Start()
    {
         sc =GetComponent<SphereCollider> ();
         sc .radius=area_radius;
         nav =GetComponent<NavMeshObstacle> ();
         nav.radius =area_radius-1;
    }






}


