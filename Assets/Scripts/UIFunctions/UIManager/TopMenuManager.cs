using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMenuManager : MonoBehaviour
{
    public ProductionListActor productionListActor;
    public void ProductionListButton() 
    {
        if (!UIManager.Instance.busy)
        {
            productionListActor.productionListScaleOfficer.ProductionListOnOffController();
        }     
    }

    public void BuildingSelectionButton(int type) 
    {
        productionListActor.productionListScaleOfficer.ProductionListOnOffController();
        GridManager.Instance.buildingCreateOfficer.CreateABuilding(type);
    }

    public void ChangePasswordButton() 
    {
        ArmyManager.Instance.ChangeThePassword();
    }
}
