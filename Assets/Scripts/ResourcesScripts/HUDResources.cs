using System.Collections.Generic;
using UnityEngine;

public class HUDResources : MonoBehaviour
{
   public List<GameObject> ResourceLog;
   public static HUDResources instance;

   private void Start()
   {
      instance = this;
   }
   
   
}
