using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnPlatform : MonoBehaviour
{
   public static UnityEvent ActiveDroneExpired = new UnityEvent();
   private int droneCount = 0;

   public GameObject DronePrefab;
   public GameObject DroneParent;
   public GameObject MainCamera;


   // Start is called before the first frame update
   void Start()
   {
      ActiveDroneExpired.AddListener(SpawnNewDrone);
      SpawnNewDrone();
   }

   private void OnDestroy()
   {
      ActiveDroneExpired.RemoveListener(SpawnNewDrone);
   }

   public void SpawnNewDrone()
   {
      GameObject newDrone = Instantiate(DronePrefab, this.transform.position, Quaternion.identity, DroneParent.transform);
      MainCamera.transform.parent = newDrone.transform;
      MainCamera.transform.localPosition = new Vector3(0, 0, -10);
      newDrone.name = "Drone" + ++droneCount;
      if(droneCount > 1)
      {
         //Dont show this message when spawnning the forst drone.
         TextPopupManager.Instance.QueueText(string.Format("Drone power expired. Launching new drone.\n\nDrone number {0} launch complete.", droneCount));
      }
   }
}
