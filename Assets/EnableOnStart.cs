using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
   public GameObject objectToEnable;
    // Start is called before the first frame update
    void Start()
    {
      objectToEnable.SetActive(true);
    }

}
