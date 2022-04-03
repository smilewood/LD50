using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageInteractable : InteractableEvent
{
   public bool RepeatableMessage = true;
   [TextArea]
   public string message;

   private bool messageShown = false;

   public override void ActionOnInteraction()
   {
      if(RepeatableMessage || !messageShown)
      {
         //Show the message
         TextPopupManager.Instance.QueueText(message);
      }
   }
}
