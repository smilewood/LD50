using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatteryUI : MonoBehaviour
{
   public static UnityEvent<float> BatteryPercentageChanged = new UnityEvent<float>();

   private float maxY;
   
   // Start is called before the first frame update
   void Start()
   {
      BatteryPercentageChanged.AddListener(this.ChangeBatteryPercent);
      maxY = transform.localScale.y;
   }

   private void OnDestroy()
   {
      BatteryPercentageChanged.RemoveListener(this.ChangeBatteryPercent);
   }

   public void ChangeBatteryPercent(float percent)
   {
      transform.localScale = new Vector3(transform.localScale.x, maxY * percent, transform.localScale.z);
   }
}
