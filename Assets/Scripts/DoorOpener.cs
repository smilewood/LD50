using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   public Sprite DoorClosedSprite;
   public Sprite DoorOpenSprite;

   void Start()
   {
      doorSprite = this.GetComponent<SpriteRenderer>();
      doorSprite.sprite = IsOpen ? DoorOpenSprite : IsLocked ? DoorLockedSprite : DoorClosedSprite;
   }

   public bool OpenDoor()
   {
      if (!IsLocked)
      {
         Debug.Log("opening door");
         IsOpen = true;
         doorSprite.sprite = DoorOpenSprite;
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
   }

   public override void Lock()
   {
      IsLocked = true;
      IsOpen = false;
      doorSprite.sprite = DoorLockedSprite;
   }

   public override void Unlock()
   {
      if (IsLocked)
      {
         IsLocked = false;
         doorSprite.sprite = DoorClosedSprite;
      }
   }
}
