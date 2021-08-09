using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoldierPerson
{
    public string name = "";
    public float hp = 3f, damage = 2f;
    public SoldierActor soldierActor;
    public abstract void Process();
}

public class Soldier1 : SoldierPerson 
{   
    public Soldier1(SoldierActor _soldierActor)
    {
        soldierActor = _soldierActor;
    }
    public override void Process()
    {
        name = "soldier1";
        hp = 10f;
        damage = 10f;
        soldierActor.spriteRenderer.color = Color.black;
        soldierActor.soldierHPOfficer.SyncTheHP(true);
    }
}
public class Soldier2 : SoldierPerson
{
    public Soldier2(SoldierActor _soldierActor)
    {
        soldierActor = _soldierActor;
    }
    public override void Process()
    {
        name = "soldier2";
        hp = 10f;
        damage = 5f;
        soldierActor.spriteRenderer.color = Color.red;
        soldierActor.soldierHPOfficer.SyncTheHP(true);
    }
}

public class Soldier3 : SoldierPerson
{
    public Soldier3(SoldierActor _soldierActor)
    {
        soldierActor = _soldierActor;
    }
    public override void Process()
    {
        name = "soldier3";
        hp = 10f;
        damage = 2f;
        soldierActor.spriteRenderer.color = Color.yellow;
        soldierActor.soldierHPOfficer.SyncTheHP(true);
    }
}
public class SoldierPersonFactory
{
    public SoldierPerson GetSoldierPerson(string soldierType, SoldierActor _soldierActor)
    {
        switch (soldierType)
        {
            case "soldier1":
                return new Soldier1(_soldierActor);
            case "soldier2":
                return new Soldier2(_soldierActor);
            case "soldier3":
                return new Soldier3(_soldierActor);
            default:
                return null;
        }
    }
}