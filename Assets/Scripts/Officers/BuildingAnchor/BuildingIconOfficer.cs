using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingIconOfficer : MonoBehaviour
{
    [SerializeField] Transform barrackIcon, powerPlantIcon;
    public Sprite selectedSprite;
    public void SetIcon(bool barrack)
    {
        GameObject tempIcon = ((barrack) ? barrackIcon : powerPlantIcon).gameObject;
        tempIcon.SetActive(true);
        selectedSprite = tempIcon.GetComponent<SpriteRenderer>().sprite;
    }
}
