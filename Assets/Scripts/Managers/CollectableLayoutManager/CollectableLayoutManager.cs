using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectables
{
   public class CollectableLayoutManager : MonoBehaviour
   {
      public CollectablesLayout prefabLayout;
      public Transform container;
      public List<CollectablesLayout> collectablesLayouts;

      private void Start()
      {
         CreateCollectables();
      }

      private void CreateCollectables()
      {
         foreach (var setup in CollectableManager.Instance.collectablesSetups)
         {
            var collectable = Instantiate(prefabLayout,container);
            collectable.Load(setup);
            collectablesLayouts.Add(collectable);
         }
      }
   }
}