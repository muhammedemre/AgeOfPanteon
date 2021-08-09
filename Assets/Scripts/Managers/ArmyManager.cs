using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyManager : MonoBehaviour
{
    public static ArmyManager Instance;
    [SerializeField] Transform soldierPool, soldier;
    public List<Transform> availableSoldiers = new List<Transform>();
    [SerializeField] int numberOfTheSoldiersToPool;
    [SerializeField] float createPosRandomAddition;

    Army army = new Army();

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
        CreateThePool();
    }

    public void SubscribeToTheArmy(Soldier soldier)
    {
        army.Attach(soldier);
    }
    public void UnsubscribeToTheArmy(Soldier soldier) 
    {
        army.Detach(soldier);
    }

    public void SetTheSecretData(string newSecretData) 
    {
        army.SecretData = newSecretData;
    }

    void CreateThePool() 
    {
        for (int i = 0; i < numberOfTheSoldiersToPool; i++)
        {
            Transform tempSoldier = Instantiate(soldier, soldierPool);
            availableSoldiers.Add(tempSoldier);
            tempSoldier.gameObject.SetActive(false);
        }
    }

    public void ChangeThePassword() 
    {
        SetTheSecretData(Random.Range(0,100).ToString());
    }

    public void GetASoldierFromThePool(string soldierType, BuildingActor buildingActor) 
    {
        Transform soldier = availableSoldiers[0];
        soldier.gameObject.SetActive(true);
        soldier.GetComponent<SoldierActor>().ActivateTheSoldier(soldierType);
        Vector3 newPos = buildingActor.transform.position + 
            new Vector3(Random.Range(-createPosRandomAddition, createPosRandomAddition), 
            Random.Range(-createPosRandomAddition, createPosRandomAddition), 0f);
        soldier.transform.position = newPos;
        availableSoldiers.RemoveAt(0);
    }
}
