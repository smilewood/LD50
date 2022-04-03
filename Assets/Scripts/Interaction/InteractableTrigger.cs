using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class InteractableTrigger : MonoBehaviour
{
   public static Dictionary<Vector3Int, List<InteractableTrigger>> TriggerPositions
   {
      get
      {
         if(triggers is null)
         {
            triggers = new Dictionary<Vector3Int, List<InteractableTrigger>>();
         }
         return triggers;
      }
   }
   private static Dictionary<Vector3Int, List<InteractableTrigger>> triggers;


   static Tilemap floorMap;

   public bool BlocksMovement;

   public Vector2Int triggerSize = new Vector2Int(1, 1);

   private List<InteractableEvent> eventsToTrigger;

   // Start is called before the first frame update
   public virtual void Start()
   {
      if (floorMap is null)
      {
         floorMap = GameObject.Find("FloorMap").GetComponent<Tilemap>();
      }

      for (int i = 0; i < triggerSize.x; ++i)
      {
         for (int j = 0; j < triggerSize.y; ++j)
         {
            AddToTriggers(floorMap.WorldToCell(this.transform.position + new Vector3(i, j, 0)), this);
         }
      }

      eventsToTrigger = new List<InteractableEvent>(this.GetComponents<InteractableEvent>());
   }

   private void AddToTriggers(Vector3Int position, InteractableTrigger trigger)
   {
      if (!TriggerPositions.ContainsKey(position))
      {
         TriggerPositions.Add(position, new List<InteractableTrigger>());
      }
      TriggerPositions[position].Add(trigger);
   }

   private void OnDestroy()
   {
      foreach (Vector3Int val in TriggerPositions.Where(p => p.Value.Contains(this)).Select(p => p.Key).ToList())
      {
         TriggerPositions.Remove(val);
      }
   }

   public void TriggerAction()
   {
      foreach(InteractableEvent ie in eventsToTrigger)
      {
         if (ie.Active)
         {
            ie.ActionOnInteraction();
         }
      }
   }

}
