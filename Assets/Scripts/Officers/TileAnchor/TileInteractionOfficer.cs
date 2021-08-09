using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileInteractionOfficer : MonoBehaviour
{
    [SerializeField] TileActor tileActor;
    private void OnMouseEnter()
    {
        if (!IsOverAnUIItem())
        {
            tileActor.tileVisualOfficer.HighlightController(true);
        }        
    }
    private void OnMouseExit()
    {       
        tileActor.tileVisualOfficer.HighlightController(false);
    }

    private void OnMouseDown()
    {
        if (!IsOverAnUIItem())
        {
            CheckIfMouseIsOverASoldier();
            GridManager.Instance.GridSelection(tileActor.tileID);
        }       
    }

    void CheckIfMouseIsOverASoldier() 
    {
        InputManager.Instance.SoldierSelectionControl();
    }

    bool IsOverAnUIItem() 
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
