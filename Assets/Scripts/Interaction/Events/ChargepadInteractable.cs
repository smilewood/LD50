using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ChargepadInteractable : InteractableEvent
{
   public bool singleUse = true;
   public Sprite ChargeUsedSprite;
   private Sprite ChargedSprite;
   private SpriteRenderer image;
   private Light2D activeLight;

   private void Start()
   {
      activeLight = GetComponent<Light2D>();
      image = GetComponent<SpriteRenderer>();
      ChargedSprite = image.sprite;
      SpawnPlatform.ActiveDroneExpired.AddListener(() => 
      { image.sprite = ChargedSprite; this.Active = true; activeLight.enabled = true; });
   }

   public override void ActionOnInteraction()
   {
      TextPopupManager.Instance.QueueText("Charge Restored!");
      DroneController.CurrentDrone.Recharge();
      if(singleUse)
      {
         image.sprite = ChargeUsedSprite;
         this.Active = false;
         activeLight.enabled = false;
      }
   }
}
