using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public TileCreateOfficer tileCreateOfficer;
    public BuildingCreateOfficer buildingCreateOfficer;
    public BuildingPlacementOfficer buildingPlacementOfficer;
    
    [HideInInspector] public static GridManager Instance;

    public Dictionary<Vector2, TileActor> tileDictionary = new Dictionary<Vector2, TileActor>();
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start()
    {
        tileCreateOfficer.CreateTheGridMap();
    }

    public void GridSelection(Vector2 tileID) 
    {
        if (InputManager.Instance.placingABuilding)
        {
            if (tileDictionary[tileID].containedBuilding == null)
            {
                PlaceABuilding(tileID);
            }
            else
            {
                BussyPlaceWarning();
            }
        }
        else
        {
            if (tileDictionary[tileID].containedBuilding != null)
            {
                DisplayInfo(tileID);
            }
        }

    }
    void PlaceABuilding(Vector2 tileID)     
    {
        Vector2 tilePosition = tileDictionary[tileID].transform.position;
        buildingPlacementOfficer.PlaceTheBuilding(tilePosition, tileID);
        NavmeshPreperation();
    }

    void DisplayInfo(Vector2 tileID) 
    {
        UIManager.Instance.busy = true;
        BuildingActor buildingActor = tileDictionary[tileID].containedBuilding.GetComponent<BuildingActor>();
        UIManager.Instance.buildingBoxActor.gameObject.SetActive(true);

        Sprite icon = buildingActor.buildingIconOfficer.selectedSprite;
        string title = buildingActor.building.name;
        float hp = buildingActor.building.hp;
        Vector2 dimension = buildingActor.building.dimension;
        UIManager.Instance.buildingBoxActor.GetInfo(icon, title, hp, dimension, buildingActor);
    }

    void BussyPlaceWarning() 
    { WarningBoxActor warningBoxActor = UIManager.Instance.warningBoxActor;
        warningBoxActor.gameObject.SetActive(true);
        StartCoroutine(warningBoxActor.boxCoseDelayer());
    }

    public void NavmeshPreperation() 
    {
        foreach (TileActor tileActor in tileDictionary.Values) 
        {
            if (tileActor.containedBuilding != null)
            {
                tileActor.gameObject.layer = 8;
            }
            else
            {
                tileActor.gameObject.layer = 0;
            }
        }
        AstarPath.active.Scan();
    }
}
