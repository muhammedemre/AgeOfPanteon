using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    [SerializeField] Transform destinationObjectContainer, targetInstance;

    [SerializeField] SoldierActor selectedSoldierActor;
    public bool placingABuilding = false;
    public bool selectedASoldier = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftClickHandler();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RightClickHandler();
        }
    }

    void LeftClickHandler()    
    {
        DeselectionASoldier();
             
        if (!placingABuilding)
        {
            SoldierSelectionControl();
        }
    }

    void RightClickHandler() 
    {
        if (selectedASoldier)
        {
            AttackControl();
            MoveTheSoldier();
        }
    }

    public void SoldierSelectionControl()     
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hits.Length != 0)
        {
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.name.Contains("Soldier"))
                {
                    selectedASoldier = true;
                    UIManager.Instance.busy = true;
                    selectedSoldierActor = hit.transform.GetComponent<SoldierActor>();
                    selectedSoldierActor.soldierHighlightOfficer.Highlight(true);
                    return;
                }
            }
        }
    }

    void DeselectionASoldier() 
    {
        if (selectedASoldier)
        {
            selectedASoldier = false;
            UIManager.Instance.busy = false;
            selectedSoldierActor.soldierHighlightOfficer.Highlight(false);
            selectedSoldierActor = null;
        }        
    }

    public void AttackControl()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if (hits.Length != 0)
        {
            foreach (RaycastHit2D hit in hits)
            {
                print("HIT : " + hit.transform.name);
                if (hit.transform.name.Contains("Soldier") || (hit.transform.tag =="Tile" && hit.transform.GetComponent<TileActor>().containedBuilding != null))
                {
                    selectedSoldierActor.soldierAttackOfficer.target = hit.transform;
                }
            }
        }
    }

    void MoveTheSoldier() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        Transform tempTarget = Instantiate(targetInstance, mousePos, Quaternion.identity, destinationObjectContainer);
        selectedSoldierActor.aIDestinationSetter.target = tempTarget;
        Destroy(tempTarget.gameObject, 10f);
    }

    bool IsOverAnUIItem()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
