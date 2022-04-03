using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargepadInteractable : InteractableEvent
{
   public bool singleUse = true;
   public Sprite ChargeUsedSprite;

   public override void ActionOnInteraction()
   {
      TextPopupManager.Instance.QueueText("Charge Restored!");
      DroneController.CurrentDrone.Recharge();
      if(singleUse)
      {
         GetComponent<SpriteRenderer>().sprite = ChargeUsedSprite;
         this.Active = false;
      }
   }
}
