using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinInteractable : InteractableEvent
{
   public override void ActionOnInteraction()
   {
      MenuFunctions.Instance.ShowMenu("Win");
   }
}
