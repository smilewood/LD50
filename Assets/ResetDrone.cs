using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDrone : MonoBehaviour
{
   public void KillDrone()
   {
      DroneController.CurrentDrone.ResetDrone();
   }
}
