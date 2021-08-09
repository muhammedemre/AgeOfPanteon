using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMouseFollowOfficer : MonoBehaviour
{
    public bool mouseFollow = false;

    private void Start()
    {
        mouseFollow = true;
        InputManager.Instance.placingABuilding = true;
    }

    private void Update()
    {
        if (mouseFollow)
        {
            MouseFollow();
        }
    }

    void MouseFollow() 
    {
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = currentPos;
    }

}
