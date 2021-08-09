using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BuildingBoxActor : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI textTitle, textHp, textDim;
    [SerializeField] Transform panel;

    BuildingProductionActor buildingProductionActor;

    public void GetInfo(Sprite icon, string title, float hp, Vector2 dimension, BuildingActor buildingActor) 
    {
        image.sprite = icon;
        textTitle.text = title;
        textHp.text = "HP : "+hp.ToString();
        textDim.text = "DIM : "+dimension[0] + "x" + dimension[1];

        buildingProductionActor = buildingActor.buildingProductionActor;

        if (title == "barrack")
        {
            panel.gameObject.SetActive(true);
        }
        else
        {
            panel.gameObject.SetActive(false);
        }
    }

    public void CloseTheBuildingBox() 
    {
        UIManager.Instance.busy = false;
        gameObject.SetActive(false);
    }

    public void CreateSoldierButton(int soldierType) 
    {
        buildingProductionActor.ProduceASoldier(soldierType);
    }

}
