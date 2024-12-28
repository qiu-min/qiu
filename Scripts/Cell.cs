using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Plant currentPlant;//每个格子上是否已经有格子
    private void OnMouseDown()
    {
        print("Cell OnMouseDown");
        HandManager.Instance.OnCellClick(this);
    }

    public bool AddPlant(Plant plant)
    {
        if (currentPlant != null) return false;
        currentPlant = plant;
        currentPlant.transform.position = transform.position;
        plant.TransitionToEnable();
        return true;
    }
}
