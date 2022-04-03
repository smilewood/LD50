using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGroup : InteractableEvent
{
   public List<InteractableEvent> EventGroup;
   public InteractableGroup NextGroup;

   protected bool EnableOnCall = false;

   private void EnableNextTime()
   {
      this.SetActive();
      EnableOnCall = true;
   }

   private void Start()
   {
      //Set all grouped events inactive, we will call them ourself
      foreach (InteractableEvent e in EventGroup)
      {
         e.Active = false;
      }
   }

   public override void ActionOnInteraction()
   {
      if (EnableOnCall)
      {
         EnableOnCall = false;
         return;
      }

      TriggerGroupedActions();
      MoveToNextGroup();
   }

   protected void TriggerGroupedActions()
   {
      foreach (InteractableEvent e in EventGroup)
      {
         e.ActionOnInteraction();
      }
   }

   protected void MoveToNextGroup()
   {
      if(!(NextGroup is null))
      {
         Active = false;
         NextGroup.EnableNextTime();
      }
   }
}
