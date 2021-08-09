using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHPOfficer : MonoBehaviour
{
    [SerializeField] BuildingActor buildingActor;
    [SerializeField] HealthBarOfficer healthBarOfficer;
    public bool testDeath = false;

    [SerializeField] float hp;

    private void Update()
    {
        if (testDeath)
        {
            testDeath = false;
            Die();
        }
    }

    public void SyncTheHP(bool firstUpdate)
    {
        hp = buildingActor.building.hp;
        healthBarOfficer.UpdateSliderWithCurrentHealth(hp, firstUpdate);
    }
    public void GetDamage(float damage)
    {
        SyncTheHP(false);
        if (hp - damage >= 0)
        {
            hp -= damage;
        }
        else
        {
            hp = 0;
        }

        if (hp <= 0)
        {
            Die();
        }
        buildingActor.building.hp = hp;
        SyncTheHP(false);
    }
    void Die()
    {
        Destroy(healthBarOfficer.currentHpBar);
        buildingActor.tileActorThatBuildingIsOn.containedBuilding = null;
        GridManager.Instance.NavmeshPreperation();
        Destroy(gameObject);
    }
}
