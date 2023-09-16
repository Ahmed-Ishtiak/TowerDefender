using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 3;
    [SerializeField] Tower towerPrefab;
    Queue<Tower> towerQueue = new Queue<Tower>();
    [SerializeField] Transform towerParent;
   

    public void AddTower(Waypoint baseWayPoint)
    {
        int towerNumber = towerQueue.Count;
        if (towerNumber <= towerLimit)
        {
            InstantiateTower(baseWayPoint);
        }
        else
        {
            MoveExistingTower(baseWayPoint);
        }
    }
    private void InstantiateTower(Waypoint basewaypoint)
    {
        var newTower = Instantiate(towerPrefab, basewaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent;
        basewaypoint.isPlaceable = true;

        newTower.baseWayPoint = basewaypoint;
        basewaypoint.isPlaceable = false;
        towerQueue.Enqueue(newTower);
    }
    private  void MoveExistingTower(Waypoint newbaseWayPoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWayPoint.isPlaceable = true;
 
        newbaseWayPoint.isPlaceable = false;
        oldTower.baseWayPoint = newbaseWayPoint;
        oldTower.transform.position = newbaseWayPoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
