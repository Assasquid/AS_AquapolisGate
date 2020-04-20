using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int maxNumbTowers = 5;
    [SerializeField] Tower towerPrefab;

    public void AddTower(Waypoint baseWaypoint)
    {
        //var towers = FindObjectsOfType<Tower>();
        // int numTowers = towers.Length();
        var towers = FindObjectsOfType<Tower>().Length;
        //if (numTowers < maxNumbTowers)
        if (towers < maxNumbTowers)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveTower();
        }
    }

        private void MoveTower()
        {
            Debug.Log("Max towers reached.");
        }

        private void InstantiateNewTower(Waypoint baseWaypoint) 
        {
            Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
            baseWaypoint.isPlaceable = false;
        }

}
