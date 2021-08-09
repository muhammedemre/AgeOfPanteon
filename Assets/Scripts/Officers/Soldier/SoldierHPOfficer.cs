using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierHPOfficer : MonoBehaviour
{
    [SerializeField] SoldierActor soldierActor;
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
        hp = soldierActor.soldierPerson.hp;
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
        soldierActor.soldierPerson.hp = hp;
        SyncTheHP(false);
    }
    void Die()   
    {
        Destroy(healthBarOfficer.currentHpBar);
        soldierActor.DeactivateTheSoldier();
    }
}
