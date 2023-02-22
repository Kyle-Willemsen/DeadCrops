using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestAll : MonoBehaviour
{
    PlantedCrop plantedeCrops;


    public void Update()
    {
        plantedeCrops = FindObjectOfType<PlantedCrop>();
    }

    public void HarvestAllCrops()
    {
        plantedeCrops.Harvest();   
    }
}
