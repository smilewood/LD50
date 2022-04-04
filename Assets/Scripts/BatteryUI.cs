using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;

public class BatteryUI : MonoBehaviour
{
   public static UnityEvent<float> BatteryPercentageChanged = new UnityEvent<float>();

   private float maxY;
   private Light2D glow;

   public float MinLightPercentage;

   // Start is called before the first frame update
   void Start()
   {
      BatteryPercentageChanged.AddListener(this.ChangeBatteryPercent);
      maxY = transform.localScale.y;
      glow = GetComponent<Light2D>();
   }

   private void OnDestroy()
   {
      BatteryPercentageChanged.RemoveListener(this.ChangeBatteryPercent);
   }

   public void ChangeBatteryPercent(float percent)
   {
      Debug.Assert(percent >= 0 && percent <= 1, "Setting battery to invalid value");
      transform.localScale = new Vector3(transform.localScale.x, maxY * percent, transform.localScale.z);
      glow.intensity = percent > 0 ? Mathf.Lerp(MinLightPercentage, 1, percent) : 0;
   }
}
