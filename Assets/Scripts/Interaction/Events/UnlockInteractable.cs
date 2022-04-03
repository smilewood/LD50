using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnlockInteractableType
{
   Unlock,
   Lock,
   Toggle
}
public class UnlockInteractable : InteractableEvent
{
   public UnlockInteractableType InteractAction;

   public Unlockable ToUnlock;

   public override void ActionOnInteraction()
   {
      switch (InteractAction)
      {
         case UnlockInteractableType.Unlock:
         {
            ToUnlock.Unlock();
            break;
         }
         case UnlockInteractableType.Lock:
         {
            ToUnlock.Lock();
            break;
         }
         case UnlockInteractableType.Toggle:
         {
            if (ToUnlock.Locked)
            {
               ToUnlock.Unlock();
            }
            else
            {
               ToUnlock.Lock();
            }
            break;
         }
      }
   }
}
