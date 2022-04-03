using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagLockedGroup : InteractableGroup
{
   public string FlagToCheck;
   public override void ActionOnInteraction()
   {
      if (EnableOnCall)
      {
         EnableOnCall = false;
         return;
      }

      if (FlagInteractable.Flags.Contains(FlagToCheck))
      {
         NextGroup.SetActive();
         NextGroup.ActionOnInteraction();
      }
      else
      {
         TriggerGroupedActions();
      }

   }
}
