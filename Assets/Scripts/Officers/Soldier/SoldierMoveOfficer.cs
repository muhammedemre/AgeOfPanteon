using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMoveOfficer : MonoBehaviour
{
    [SerializeField] SoldierActor soldierActor;
    [SerializeField] float reachCheckFrequency;
    float nextReachCheck;
    void Start()
    {
        nextReachCheck = Time.time + reachCheckFrequency;
    }

    void Update()
    {
        //ReachCheck();
    }

    void ReachCheck() 
    {
        if (nextReachCheck < Time.time)
        {
            nextReachCheck = Time.time + reachCheckFrequency;
            if (soldierActor.aiPath.reachedDestination) 
            {
                soldierActor.aiPath.canMove = false;
            }
        }
    }
}
