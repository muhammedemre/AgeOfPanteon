using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreateOfficer : MonoBehaviour
{
    [SerializeField] private Transform tile, tileContainer;
    [SerializeField] private int tileAmountAtHorizontal, tileAmountAtVertical;
    [SerializeField] float tileDiameter, firstYPos, firstXPos;
    public void CreateTheGridMap()
    {
        float currentYPos = firstYPos;
        bool even = true;
        for (int i = 0; i < tileAmountAtVertical; i++)
        {
            for (int i2 = 0; i2 < tileAmountAtHorizontal; i2++)
            {               
                Vector2 tempTilePos = new Vector2(firstXPos + (i2*tileDiameter), currentYPos);
                Transform tempTile = Instantiate(tile, tempTilePos, Quaternion.identity, tileContainer);

                TileActor tempTileActor = tempTile.GetComponent<TileActor>();
                tempTileActor.tileID = new Vector2(i2, i);
                tempTileActor.gameObject.name = tempTileActor.tileID.ToString();
                tempTileActor.tileVisualOfficer.ColorTheTile(even);
                GridManager.Instance.tileDictionary.Add(tempTileActor.tileID, tempTileActor);
                even = !even;
            }
            currentYPos += tileDiameter;
            even = !even;
        }
    }
}
