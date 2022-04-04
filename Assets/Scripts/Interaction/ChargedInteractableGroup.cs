using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedInteractableGroup : InteractableGroup
{
   public int ChargeRequired;

   [TextArea]
   public string DefaultMessage;

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
         if(DefaultMessage != string.Empty)
         {
            TextPopupManager.Instance.QueueText(DefaultMessage);
         }
         TriggerGroupedActions();
      }
   }

}
