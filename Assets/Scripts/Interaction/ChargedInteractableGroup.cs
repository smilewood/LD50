using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedInteractableGroup : InteractableGroup
{
   public int ChargeRequired;

   public override void ActionOnInteraction()
   {
      if (EnableOnCall)
      {
         EnableOnCall = false;
         return;
      }

      if (DroneController.CurrentDrone.DrainCharge(ChargeRequired))
      {
         this.Active = false;
         NextGroup.SetActive();
         NextGroup.ActionOnInteraction();
      }
      else
      {
         TriggerGroupedActions();
      }
   }

}
