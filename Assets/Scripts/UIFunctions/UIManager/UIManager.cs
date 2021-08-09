using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TopMenuManager topMenuManager;
    public BuildingBoxActor buildingBoxActor;
    public WarningBoxActor warningBoxActor;
    public Transform sliderContainer;

    public bool busy = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }
}
