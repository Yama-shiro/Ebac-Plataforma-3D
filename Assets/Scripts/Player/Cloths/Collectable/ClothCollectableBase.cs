using System;
using System.Collections;
using System.Collections.Generic;
using Cloth;
using UnityEngine;

namespace Cloth
{
    public class ClothCollectableBase : MonoBehaviour
    {
        public string compareTag = "Player"; 
        public ClothBaseSO clothBaseSo;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(compareTag))
            {
                Collect();
            }
        }

        public virtual void Collect()
        {
            HideObject();
            var setup = ClothManager.Instance.GetSetupByType(clothBaseSo.typeCloth);
            ApplyPowerUpTexture(setup,clothBaseSo.duration);
            ClothManager.Instance.SaveCloth(clothBaseSo,gameObject.GetInstanceID());
        }

        private void HideObject()
        {
            ClothManager.Instance.RemoveCloth(gameObject.GetInstanceID());
            gameObject.SetActive(false);
        }

        public static void ApplyPowerUpTexture(ClothSetup clothSetup,float duration)
        {
            Player.Instance.ChangeTexture(clothSetup,duration);
        }
    }
}
