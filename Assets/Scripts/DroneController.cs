using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DroneController : MonoBehaviour
{
   public static DroneController CurrentDrone
   {
      get;
      private set;
   }

   public int Battery
   {
      get;
      private set;
   }
   private Tilemap floorMap;
   public Animator droneAnimation;
   public BatteryUI thisBattery;

   // Start is called before the first frame update
   void Start()
   {
      Battery = 100;
      floorMap = GameObject.Find("FloorMap").GetComponent<Tilemap>();
      CurrentDrone = this;
   }

   // Update is called once per frame
   void Update()
   {
      if (MenuFunctions.Instance.IsMenuOpen("Start"))
      {
         return;
      }

      if (Input.GetButtonDown("ResetDrone"))
      {
         ResetDrone();
      }
      // The drone can move, so do so
      Vector3 delta = new Vector3((Input.GetButtonDown("Left") ? -1 : (Input.GetButtonDown("Right") ? 1 : 0)), (Input.GetButtonDown("Down") ? -1 : (Input.GetButtonDown("Up") ? 1 : 0)));
      if (delta != Vector3.zero)
      {
         bool canMove = true;

         Vector3 newWorldPosition = this.transform.position + delta;
         Vector3Int tileMapPosition = floorMap.WorldToCell(newWorldPosition);


         //have interaction happen when moving onto an interactable
         if (InteractableTrigger.TriggerPositions.TryGetValue(tileMapPosition, out List<InteractableTrigger> triggers))
         {
            canMove &= !triggers.Any(t => t.BlocksMovement);
            foreach (InteractableTrigger trigger in triggers)
            {
               trigger.TriggerAction();
            }
         }

         //Check if the move is on the map
         if (!(floorMap.GetTile(tileMapPosition) is TileBase))
         {
            canMove = false;
         }

         if (canMove)
         {
            Battery -= 1;
            //Update UI for battery drain
            thisBattery.ChangeBatteryPercent(Battery / 100f);

            //When the battery is empty kill the drone
            if (Battery <= 0)
            {
               ResetDrone();
            }

            //TODO: Animate the movement, maybe have it face a direction at least

            this.transform.position = newWorldPosition;
         }
      }
   }

   public void ResetDrone()
   {
      droneAnimation.SetTrigger("KillDrone");
      CurrentDrone = null;
      SpawnPlatform.ActiveDroneExpired.Invoke();
      this.enabled = false;
   }

   public void Recharge()
   {
      Battery = 100;
   }

   public bool DrainCharge(int amount)
   {
      if(amount < Battery)
      {
         Battery -= amount;
         BatteryUI.BatteryPercentageChanged.Invoke(Battery / 100f);
         return true;
      }
      return false;
   }
}
