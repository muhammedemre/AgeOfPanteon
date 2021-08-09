using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProductionListScaleOfficer : MonoBehaviour
{
    [SerializeField] Transform productionListPanelContainer, topMenu;

    [SerializeField] float listMoveDuration;

    private RectTransform topMenuRect, prodListPanelContRect;
    bool panelOpen = false;
    private void Start()
    {
        topMenuRect = topMenu.GetComponent<RectTransform>();
        prodListPanelContRect = productionListPanelContainer.GetComponent<RectTransform>();
    }

    public void ProductionListOnOffController() 
    {
        if (!panelOpen)
        {
            panelOpen = true;
            ProductionListOn();
        }
        else
        {
            panelOpen = false;
            ProductionListOff();
        }
    }

    void ProductionListOn()
    {
        /*float destYPos = -(Screen.height + topMenuRect.offsetMin.y);
        DOTween.To(() => prodListPanelContRect.offsetMin, x => prodListPanelContRect.offsetMin = x,
            new Vector2(prodListPanelContRect.offsetMin.x, destYPos), listMoveDuration);*/
        prodListPanelContRect.DOScaleY(1, listMoveDuration);
    }

    void ProductionListOff()
    {
        /*DOTween.To(() => prodListPanelContRect.offsetMin, x => prodListPanelContRect.offsetMin = x,
            new Vector2(prodListPanelContRect.offsetMin.x, 0f), listMoveDuration);*/
        prodListPanelContRect.DOScaleY(0, listMoveDuration);
    }
}
