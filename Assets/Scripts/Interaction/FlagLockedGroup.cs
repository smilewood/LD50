using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagLockedGroup : InteractableGroup
{
   public string FlagToCheck;

   [TextArea]
   public string DefaultMessage;

   public override void ActionOnInteraction()
   {
      if (EnableOnCall)
      {
         EnableOnCall = false;
         return;
      }

      if (FlagInteractable.Flags.Contains(FlagToCheck))
      {
         this.Active = false;
         NextGroup.SetActive();
         NextGroup.ActionOnInteraction();
      }
      else
      {
         if (DefaultMessage != string.Empty)
         {
            TextPopupManager.Instance.QueueText(DefaultMessage);
         }
         TriggerGroupedActions();
      }

   }
}
