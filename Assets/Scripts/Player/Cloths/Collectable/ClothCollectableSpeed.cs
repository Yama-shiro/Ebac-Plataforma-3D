using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothCollectableSpeed : ClothCollectableBase
    {
       // public float targetSpeed = 2f;
        
        public override void Collect()
        {
            ClothSpeedSO clothSpeedSo = (ClothSpeedSO)clothBaseSo;
            ApplyPowerUp(clothSpeedSo.targetSpeed,clothSpeedSo.duration);
            base.Collect();
        }

        public static void ApplyPowerUp(float targetSpeed, float duration)
        {
            Player.Instance.ChangeSpeed(targetSpeed,duration);
        }
    }
}
