using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BuildingActor : MonoBehaviour
{
    public BuildingMouseFollowOfficer buildingMouseFollowOfficer;
    public BuildingIconOfficer buildingIconOfficer;
    public BuildingProductionActor buildingProductionActor;
    public BuildingHPOfficer buildingHPOfficer;

    public TileActor tileActorThatBuildingIsOn;
    public float hp = 0;
    public Building building;
    public string buildingType = "";

    public void DefineTheTypeOfTheBuilding(bool barrack) 
    {
        var buildingFactory = new BuildingFactory();
        if (barrack)
        {
            building = buildingFactory.GetBuilding("barrack", this);
            building.Process();
            hp = building.hp;
            buildingType = "barrack";
        }
        else
        {
            building = buildingFactory.GetBuilding("powerplant", this);
            building.Process();
            hp = building.hp;
            buildingType = "powerplant";
        }
    }
    
}
