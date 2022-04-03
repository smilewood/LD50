using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableTrigger))]
public class InteractableEvent : MonoBehaviour
{
   public bool Active;
   public virtual void SetActive(bool active = true)
   {
      this.Active = active;
   }

   public virtual void ActionOnInteraction()
   {
      return;
   }
}
