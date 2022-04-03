using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TextPopupManager : MonoBehaviour
{
   #region Singleton

   public static TextPopupManager Instance
   {
      get
      {
         if(instance is null)
         {
            Debug.LogError("Trying to use TextManager before initialization");
         }
         return instance;
      }
   }
   private static TextPopupManager instance;
   #endregion Singleton

   public Text text;
   public GameObject popup;

   private bool showing = false;
   private Queue<string> TextQueue;
   // Start is called before the first frame update
   void Start()
   {
      if(!(instance is null))
      {
         Debug.LogError("Why is there already a text manager??");
      }
      instance = this;

      popup.SetActive(false);
      TextQueue = new Queue<string>();
   }

   // Update is called once per frame
   void Update()
   {
      if (showing && Input.anyKeyDown)
      {
         if (TextQueue.Any())
         {
            ShowNextText();
         }
         else
         {
            popup.SetActive(false);
            showing = false;
         }
      }
   }

   private void ShowNextText()
   {
      text.text = TextQueue.Dequeue();
      popup.SetActive(true);
      showing = true;
   }

   public void QueueText(string textToShow)
   {
      TextQueue.Enqueue(textToShow);
      if (!showing)
      {
         ShowNextText();
      }
   }
}
