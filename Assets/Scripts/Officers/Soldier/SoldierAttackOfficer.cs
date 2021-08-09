using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackOfficer : MonoBehaviour
{
    [SerializeField] SoldierActor soldierActor;
    public Transform target;

    public void Attack() 
    {
        float damage = soldierActor.soldierPerson.damage;
        if (target.GetComponent<SoldierActor>())
        {
            target.GetComponent<SoldierActor>().soldierHPOfficer.GetDamage(damage);
        }
        else if (target.GetComponent<TileActor>())
        {
            target.GetComponent<TileActor>().containedBuilding.GetComponent<BuildingActor>().buildingHPOfficer.GetDamage(damage);
        }
        target = null;
    }
}
