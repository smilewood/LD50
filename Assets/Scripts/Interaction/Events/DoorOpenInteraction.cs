using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DoorOpener))]
public class DoorOpenInteraction : InteractableEvent
{
   private DoorOpener door;
   private InteractableTrigger trigger;

   public void Start()
   {
      trigger = GetComponent<InteractableTrigger>();
      door = GetComponent<DoorOpener>();
      trigger.BlocksMovement = !door.IsOpen;
   }
   public override void ActionOnInteraction()
   {
      if (!door.IsOpen)
      {
         door.OpenDoor();
         trigger.BlocksMovement = !door.IsOpen;
      }
   }
}
