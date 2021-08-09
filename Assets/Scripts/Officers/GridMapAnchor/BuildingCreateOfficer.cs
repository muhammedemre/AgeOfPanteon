using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreateOfficer : MonoBehaviour
{
    
    [SerializeField] Transform building, buildingContainer;

    public void CreateABuilding(int type) 
    {
        Transform tempBuilding = Instantiate(building, buildingContainer);
        GridManager.Instance.buildingPlacementOfficer.currentPlacingBuilding = tempBuilding;

        tempBuilding.GetComponent<BuildingActor>().DefineTheTypeOfTheBuilding((type == 0)? true : false);
    }
}
