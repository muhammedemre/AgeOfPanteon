using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacementOfficer : MonoBehaviour
{
    public Transform currentPlacingBuilding;
    public void PlaceTheBuilding(Vector2 placementPosition, Vector2 tileID) 
    {
        BuildingActor currentPlacingBuildingActor = currentPlacingBuilding.GetComponent<BuildingActor>();
        currentPlacingBuildingActor.buildingMouseFollowOfficer.mouseFollow = false;
        currentPlacingBuilding.position = placementPosition;
        InputManager.Instance.placingABuilding = false;
        GridManager.Instance.tileDictionary[tileID].containedBuilding = currentPlacingBuilding;
        currentPlacingBuildingActor.tileActorThatBuildingIsOn = GridManager.Instance.tileDictionary[tileID].GetComponent<TileActor>();



    }
}
