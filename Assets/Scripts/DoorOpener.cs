using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public abstract class Unlockable : MonoBehaviour
{
   public abstract bool Locked
   {
      get;
   }
   public abstract void Unlock();
   public abstract void Lock();
}

public class DoorOpener : Unlockable
{
   private SpriteRenderer doorSprite;

   public bool IsOpen = false;
   public bool IsLocked = false;

   public override bool Locked
   {
      get
      {
         return IsLocked;
      }
   }

   public Sprite DoorLockedSprite;
   public Color LockedLightColor;
   public Sprite DoorClosedSprite;
   public Color ClosedLightColor;
   public Sprite DoorOpenSprite;
   public Color OpenLightColor;

   public Light2D statusLight;

   void Start()
   {
      doorSprite = this.GetComponent<SpriteRenderer>();
      doorSprite.sprite = IsOpen ? DoorOpenSprite : IsLocked ? DoorLockedSprite : DoorClosedSprite;
      statusLight.color = IsOpen ? OpenLightColor : IsLocked ? LockedLightColor : ClosedLightColor;
   }

   public bool OpenDoor()
   {
      if (!IsLocked)
      {
         Debug.Log("opening door");
         IsOpen = true;
         doorSprite.sprite = DoorOpenSprite;
         statusLight.color = OpenLightColor;
         return true;
      }
      else
      {
         TextPopupManager.Instance.QueueText("Door is Locked.");
         return false;
      }
   }

   public void CloseDoor()
   {
      IsOpen = false;
      doorSprite.sprite = DoorClosedSprite;
      statusLight.color = ClosedLightColor;
   }

   public override void Lock()
   {
      IsLocked = true;
      IsOpen = false;
      doorSprite.sprite = DoorLockedSprite;
      statusLight.color = LockedLightColor;
   }

   public override void Unlock()
   {
      if (IsLocked)
      {
         IsLocked = false;
         doorSprite.sprite = DoorClosedSprite;
         statusLight.color = ClosedLightColor;
      }
   }
}
