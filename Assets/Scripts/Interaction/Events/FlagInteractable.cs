using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagInteractable : InteractableEvent
{
   private static HashSet<string> flags;
   public static HashSet<string> Flags
   {
      get
      {
         if(flags is null)
         {
            flags = new HashSet<string>();
         }
         return flags;
      }
   }

   public string FlagToSet;
   public override void ActionOnInteraction()
   {
      Flags.Add(FlagToSet);
      Debug.Log("Added " + FlagToSet + " to flags");
      this.Active = false;
   }
}
