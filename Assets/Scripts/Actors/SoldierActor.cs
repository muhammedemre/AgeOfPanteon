using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierActor : MonoBehaviour
{
    public SoldierAttackOfficer soldierAttackOfficer;
    public SoldierHPOfficer soldierHPOfficer; 
    public SoldierMoveOfficer soldierMoveOfficer;
    public SoldierHighlightOfficer soldierHighlightOfficer;
    public AIDestinationSetter aIDestinationSetter;
    public AIPath aiPath;
    
    Soldier soldierSelf;
    public SoldierPerson soldierPerson;
    public SpriteRenderer spriteRenderer;
    public string pocketForPassword = "";
    public bool activeSoldier = false;
    void Start()
    {
        soldierSelf = new Soldier(this);
        ArmyManager.Instance.SubscribeToTheArmy(soldierSelf);
    }

    public void ActivateTheSoldier(string soldierType) 
    {
        DefineTheTypeOfTheSoldier(soldierType);
        activeSoldier = true;
    }

    public void DeactivateTheSoldier()     
    {
        activeSoldier = false;
        ArmyManager.Instance.availableSoldiers.Add(transform);
        gameObject.SetActive(false);
    }

    void DefineTheTypeOfTheSoldier (string soldierType)
    {
        var soldierPersonFactory = new SoldierPersonFactory();
        soldierPerson = soldierPersonFactory.GetSoldierPerson(soldierType, this);
        soldierPerson.Process();
    }
}
