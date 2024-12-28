using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance { get; private set; }
    public List<Plant> plantList;
    private Plant currentPlant;//当前正在种植的植物，鼠标上的植物
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        FollowCursor();
    }
    //种植植物，鼠标上一次只能有一个植物
    public bool AddPlant(PlantType plantType)
    {
        if(currentPlant!= null)return false;
        Plant plantPrefab = GetPlantPrefab(plantType);
        if (plantPrefab == null)
        {
            print("要种植的植物不存在");return false;
        }
        currentPlant=GameObject.Instantiate(plantPrefab);
        return true;
    }

    private Plant GetPlantPrefab(PlantType plantType)
    {
        foreach(Plant plant in plantList)
        {
            if(plant.plantType == plantType)
            {
                return plant;
            }
        }
        return null;
    }

    void FollowCursor()
    {
        if (currentPlant == null) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        currentPlant.transform.position = mousePos;
        print("123");
    }

    public void OnCellClick(Cell cell)
    {
        if (currentPlant == null) return;
        bool isSuccess = cell.AddPlant(currentPlant);
        if (isSuccess)
        {
            currentPlant = null;
        }
    }
}
   
