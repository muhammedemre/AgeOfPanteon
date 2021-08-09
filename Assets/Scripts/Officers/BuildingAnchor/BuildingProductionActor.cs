using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProductionActor : MonoBehaviour
{
    public BuildingActor buildingActor;
    public void ProduceASoldier(int soldierType) 
    {
        print("CREATE SOLDIER TYPE : " + soldierType + buildingActor.transform.name);
        ArmyManager.Instance.GetASoldierFromThePool("soldier"+(soldierType+1).ToString(), buildingActor);
    }
}
