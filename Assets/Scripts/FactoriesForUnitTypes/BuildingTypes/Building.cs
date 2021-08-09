using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building
{
    public string name = "";
    public float hp = 3;
    public Vector2 dimension = new Vector2(1,1);
    public abstract void Process();
}

public class Barrack : Building
{
    BuildingActor buildingActor;
    public Barrack(BuildingActor _buildingActor)
    {
        buildingActor = _buildingActor;
    }
    public override void Process()
    {
        name = "barrack";
        hp = 100f;
        dimension = new Vector2(1, 1);
        buildingActor.buildingIconOfficer.SetIcon(true);

        buildingActor.buildingProductionActor = buildingActor.gameObject.AddComponent<BuildingProductionActor>();
        buildingActor.buildingProductionActor.buildingActor = buildingActor;
        buildingActor.buildingHPOfficer.SyncTheHP(true);
    }
}

public class PowerPlant : Building
{
    BuildingActor buildingActor;
    public PowerPlant(BuildingActor _buildingActor)   
    {
        buildingActor = _buildingActor;
    }
    public override void Process()
    {
        name = "powerplant";
        hp = 50f;
        dimension = new Vector2(1, 1);
        buildingActor.buildingIconOfficer.SetIcon(false);
        buildingActor.buildingHPOfficer.SyncTheHP(true);
    }
}

public class BuildingFactory 
{
    public Building GetBuilding(string buildingType, BuildingActor _buildingActor) 
    {
        switch (buildingType)
        {
            case "barrack":
                return new Barrack(_buildingActor);
            case "powerplant":
                return new PowerPlant(_buildingActor);
            default:
                return null;
        }
    }
}

