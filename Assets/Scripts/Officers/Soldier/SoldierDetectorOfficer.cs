using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDetectorOfficer : MonoBehaviour
{
    [SerializeField] SoldierActor soldierActor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == soldierActor.soldierAttackOfficer.target)
        {
            print(" oth : " + other.transform.name + " : target : " + soldierActor.soldierAttackOfficer.target.name);
            soldierActor.soldierAttackOfficer.Attack();
        }
    }
}
