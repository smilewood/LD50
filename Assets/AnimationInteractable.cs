using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInteractable : InteractableEvent
{
   public Animator target;
   public string trigger;

   public override void ActionOnInteraction()
   {
      target.SetTrigger(trigger);
   }
}
